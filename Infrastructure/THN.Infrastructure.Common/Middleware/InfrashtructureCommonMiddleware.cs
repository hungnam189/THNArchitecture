using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using THN.Infrastructure.Common.JWT;

namespace THN.Infrastructure.Common.Middleware
{
    public static class InfrashtructureCommonMiddleware
    {
        public static void AddJwt(this IServiceCollection services, IConfiguration configuration)
        {
            var options = new JwtOptions();
            var section = configuration.GetSection("jwt");
            section.Bind(options);
        }
    }
}
