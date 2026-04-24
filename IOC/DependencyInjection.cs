using Comisiones.Domain.Interfaces;
using Comisiones.Infrastructure.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace Comisiones.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddCommissionServices(this IServiceCollection services)
    {

        services.AddSingleton<ICommissionFactory, CommissionFactory>();

        return services;
    }
}