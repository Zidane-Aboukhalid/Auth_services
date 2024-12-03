using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using System.Text;
using Auth_Services.Infrastructure;
using Auth_Services.Application;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    // Écouter sur le port 80 (HTTP)
    options.ListenAnyIP(80);

    // Écouter sur le port 443 (HTTPS)
    options.ListenAnyIP(443, listenOptions =>
    {
        listenOptions.UseHttps("/path/to/your/certificate.pfx", "your-certificate-password");
    });
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
builder.Services.Configure<IdentityOptions>(options =>
{
    options.User.AllowedUserNameCharacters = string.Empty;
});

// Ajouter l'authentification avec JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        // Configurer les paramètres de validation du jeton JWT
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SecretKey"]))
    };
});

// Ajout du service de Data Protection pour la gestion des clés cryptées
builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo("/root/.aspnet/DataProtection-Keys"))
    .SetApplicationName("Auth_Services");

// Ajouter CORS pour permettre les appels cross-origin (si nécessaire)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

// Ajouter les services pour les dépendances de l'application
builder.Services.AddScoped<IYourService, YourService>();

var app = builder.Build();

// Configurer l'environnement et ajouter Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configurer les middlewares de sécurité
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

// Configurer CORS (si nécessaire)
app.UseCors("AllowAll");

app.MapControllers();

// Démarrer l'application
app.Run();
