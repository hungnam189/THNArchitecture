using Microsoft.Extensions.DependencyInjection;
using System;
using THN.Infrastructure.Data.Configuration;

namespace THN.Infrastructure.Data
{
    public static class InfrasturctureDataLayerRegistration
    {
        public static void AddInfrasturctureDataLayerRegistration(this IServiceCollection service)
        {
            service.AddScoped<IConnectionConfigExtention, ConnectionConfigExtention>();
        }
    }
}
