using Greenwich.DataPersistence.Common;
using Greenwich.DataPersistence.IRepositories;
using Greenwich.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace Greenwich.DataPersistence.Repositories
{
    public class FileSubmissionRepository : Repository<FileSubmission>, IFileSubmissionRepository
    {
        public FileSubmissionRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
