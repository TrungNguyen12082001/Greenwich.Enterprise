using Greenwich.CommonServices.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenwich.CommonServices
{
    public static class CommonServiceExtension
    {
        public static void AddCommonServices(this IServiceCollection services)
        {
            services.AddScoped<IJwtHandler, JwtHandler>();
            services.AddScoped<IEncrypter, Encrypter>();
        }
    }
}
