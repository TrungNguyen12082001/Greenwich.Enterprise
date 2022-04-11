using Greenwich.DataPersistence.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Greenwich.DataPersistence
{
    public static class DataPersistenceExtension
    {
        public static void AddDataPersistence(this IServiceCollection services)
        {
            services.AddScoped<IGEWUnitOfWork, GEWUnitOfWork>();
        }
    }
}
