using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Auth_Services.Application.Behaviours;
using System.Reflection;

namespace Auth_Services.Application;

public static class ServicesApplication
{
	public static IServiceCollection AddServicesApplication(this IServiceCollection services)
	{
		services.AddAutoMapper(Assembly.GetExecutingAssembly());
		services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
		services.AddMediatR(ctg =>
		{
			ctg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
			ctg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
		}
		);
		return services;
	}
}	
