using EDA.Consumer.Demo.Application.Common.Interfaces;
using EDA.Consumer.Demo.Infrastructure.Checks.Persistence;
using EDA.Consumer.Demo.Infrastructure.Common.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EDA.Consumer.Demo.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistenceServices(configuration);
        services.AddAdditionalServices();
    }
    
    public static void AddAdditionalServices(this IServiceCollection services)
    {
        services.AddTransient<ICheckRepository, CheckRepository>();
        services.AddTransient<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<EdaDemoDbContext>());
    }
    
}