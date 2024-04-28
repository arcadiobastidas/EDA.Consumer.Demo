using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace EDA.Consumer.Demo.Application;

public static class ApplicationServiceRegistration
{
    
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationServiceRegistration).Assembly));
    }

}