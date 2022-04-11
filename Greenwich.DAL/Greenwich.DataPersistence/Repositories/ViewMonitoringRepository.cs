using Greenwich.DataPersistence.Common;
using Greenwich.DataPersistence.IRepositories;
using Greenwich.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace Greenwich.DataPersistence.Repositories
{
    public class ViewMonitoringRepository : Repository<ViewMonitoring>, IViewMonitoringRepository
    {
        public ViewMonitoringRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
