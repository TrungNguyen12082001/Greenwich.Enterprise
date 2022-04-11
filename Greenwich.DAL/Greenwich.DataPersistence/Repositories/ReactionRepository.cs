using Greenwich.DataPersistence.Common;
using Greenwich.DataPersistence.IRepositories;
using Greenwich.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace Greenwich.DataPersistence.Repositories
{
    public class ReactionRepository : Repository<Reaction>, IReactionRepository
    {
        public ReactionRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
