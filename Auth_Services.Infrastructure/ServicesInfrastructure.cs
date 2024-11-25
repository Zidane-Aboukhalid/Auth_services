using Infra.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Auth_Services.Domain.Entitys;
using Auth_Services.Domain.Helpers;
using Auth_Services.Domain.InterfacesServices;
using Auth_Services.Infrastructure.data;
using Auth_Services.Infrastructure.Helpers;

namespace Auth_Services.Infrastructure;

public static class ServicesInfrastructure
{
	public static IServiceCollection AddServicesInfrastructure(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddIdentity<User, IdentityRole>()
			.AddEntityFrameworkStores<ApplicationDbContext>()
			.AddDefaultTokenProviders();
		try
		{
			services.AddDbContext<ApplicationDbContext>(op => op.UseSqlServer(configuration.GetConnectionString("cnx")));

		}
		catch (Exception ex)
		{
			throw new Exception("Error occurred while configuring the DbContext. See inner exception for details.", ex);
		}
		services.AddScoped<IAuthServices, AuthServices>();
		services.Configure<JWT>(configuration.GetSection("JWT"));
		services.Configure<SMTPSettings>(configuration.GetSection("SMTPSettings"));
		return services;
	}
}
