using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Auth_Services.Infrastructure;
using Auth_Services.Application;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Ajouter les services nécessaires au conteneur
builder.Services.AddControllers();

// Configurer Swagger pour la documentation de l'API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurer les services d'infrastructure
builder.Services.AddServicesInfrastructure(builder.Configuration);

// Configurer les services de l'application
builder.Services.AddServicesApplication();

// Configurer les options d'Identity
builder.Services.Configure<IdentityOptions>(options =>
{
    options.User.AllowedUserNameCharacters = string.Empty; // Limiter les caractères autorisés dans le nom d'utilisateur
});

// Configurer l'authentification JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false; // Désactiver HTTPS pour les environnements locaux (à activer en production)
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

// Ajouter la gestion des autorisations
builder.Services.AddAuthorization();

// Configurer CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

var app = builder.Build();

// Configurer le pipeline de requêtes HTTP
app.UseSwagger();
app.UseSwaggerUI();

// PAS de redirection HTTPS ici
// app.UseHttpsRedirection(); // Si t7eb matdirch 7it ma3ndekch SSL 

// Ajouter la gestion de l'authentification et de l'autorisation
app.UseAuthentication();
app.UseAuthorization();

// Appliquer la politique CORS
app.UseCors("Open");

// Mapper les contrôleurs
app.MapControllers();

app.Run();
