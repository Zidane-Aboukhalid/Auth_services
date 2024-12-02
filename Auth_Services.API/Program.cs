using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Auth_Services.Infrastructure;
using Auth_Services.Application;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Configurer Kestrel pour écouter sur le port 80
builder.WebHost.ConfigureKestrel(options =>
{
    // Écouter sur toutes les interfaces réseau au port 80 (HTTP)
    options.ListenAnyIP(80);  // Écouter sur le port 80 (sans SSL)
});

// Ajouter les services au conteneur
builder.Services.AddControllers();

// Configurer Swagger pour la documentation API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Services Infrastructure
builder.Services.AddServicesInfrastructure(builder.Configuration);

// Services Application
builder.Services.AddServicesApplication();

// Configurer les options d'Identity
builder.Services.Configure<IdentityOptions>(Options =>
{
    Options.User.AllowedUserNameCharacters = string.Empty;
});

// Ajouter l'authentification avec JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"],
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:key"]))
    };
});

// Configurer l'autorisation
builder.Services.AddAuthorization();

// Ajouter CORS pour autoriser toutes les origines
builder.Services.AddCors(options =>
{
    options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

var app = builder.Build();

// Configurer le pipeline de requêtes HTTP
app.UseSwagger();
app.UseSwaggerUI();

// Utiliser la redirection HTTP si nécessaire (ici on n'utilise pas HTTPS)
app.UseHttpsRedirection();  // Cette ligne peut être ignorée si tu veux absolument ne pas utiliser HTTPS

// Activer l'authentification et l'autorisation
app.UseAuthentication();
app.UseAuthorization();

// Utiliser CORS
app.UseCors("Open");

// Mapper les contrôleurs
app.MapControllers();

// Démarrer l'application
app.Run("http://0.0.0.0:80");  // Spécifier explicitement l'URL et le port d'écoute
