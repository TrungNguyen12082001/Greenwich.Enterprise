using Greenwich.DataPersistence.Common;
using Greenwich.DataPersistence.IRepositories;
using Greenwich.EntityFramework.Entities;
using Greenwich.Models.Responses;
using Microsoft.EntityFrameworkCore;

namespace Greenwich.DataPersistence.Repositories
{
    public class IdeaRepository : Repository<Idea>, IIdeaRepository
    {
        public IdeaRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<GetIdeasResponse>> GetIdeasBySubmissionId(int submissionId)
        {
            var query = from i in _dbSet
                        join s in _dbContext.Set<Submission>() on i.SubmissionId equals s.Id
                        where s.Id == submissionId
                        select new GetIdeasResponse { 
                            Id = i.Id,
                            Title = i.Title,
                            Description = i.Description,
                            Content = i.Content,
                            UserId = i.UserId,
                            CategoryId = i.CategoryId,
                            ClosureDate = s.ClosureDate,
                            FinalClosureDate = s.FinalClosureDate
                        };
            return await query.ToListAsync();
        }
    }
}
