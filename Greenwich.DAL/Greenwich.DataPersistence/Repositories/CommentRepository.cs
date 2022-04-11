using Greenwich.DataPersistence.Common;
using Greenwich.DataPersistence.IRepositories;
using Greenwich.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace Greenwich.DataPersistence.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
