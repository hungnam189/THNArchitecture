using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using THN.Infrastructure.Common.EncyptHelper;

namespace THN.Infrastructure.Common
{
    public static class InfrastructureCommonLayerRegistration
    {
        public static void AddInfrastructureCommonLayerRegistration(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<IEncryptor, Encryptor>();
            services.AddJwt(config);
        }
    }
}
