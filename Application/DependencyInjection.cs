using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;

public static class DependencyInjections
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        #region Automapper config

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        #endregion

        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        //services.AddHostedService<DeleteUserBackgroundService>();

        return services;
    }
}
