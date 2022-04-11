using Greenwich.DataPersistence.Common;
using Greenwich.DataPersistence.IRepositories;
using Greenwich.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace Greenwich.DataPersistence.Repositories
{
    public class SubmissionRepository : Repository<Submission>, ISubmissionRepository
    {
        public SubmissionRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
