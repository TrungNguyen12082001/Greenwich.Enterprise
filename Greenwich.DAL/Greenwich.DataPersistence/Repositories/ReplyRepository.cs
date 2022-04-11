using Greenwich.DataPersistence.Common;
using Greenwich.DataPersistence.IRepositories;
using Greenwich.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace Greenwich.DataPersistence.Repositories
{
    public class ReplyRepository : Repository<Reply>, IReplyRepository
    {
        public ReplyRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
