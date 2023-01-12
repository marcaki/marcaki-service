using System.Reflection;
using MarcakiService.Cross.CommandHandlers;
using MarcakiService.Cross.EventHandlers;
using MarcakiService.Domain.Repository;
using MarcakiService.Repository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MarcakiService.Cross.Extensions;

public static class ServicesExtensions
{
    public static void ConfigureHandlers(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        services.AddMediatR(assembly,  typeof(CreateProviderCommandHandler).Assembly);
        services.AddTransient<CreateProviderCommandHandler>();
        services.AddTransient<ProviderCreatedEventHandler>();
        
    }
    
    public static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddTransient<EventSourceContext>();
        services.AddTransient<IAggregateRepository, AggregateRepository>();
        services.AddTransient<IProviderRepository, ProviderRepository>();
    }
}