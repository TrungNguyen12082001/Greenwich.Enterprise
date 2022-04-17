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
                            FinalClosureDate = s.FinalClosureDate,
                            LikeCount = (from r in _dbContext.Set<Reaction>() 
                                         where r.IdeaId == i.Id && r.IsLike 
                                         select r.Id).Count(),
                            UnLikeCount = (from r in _dbContext.Set<Reaction>()
                                         where r.IdeaId == i.Id && r.IsUnlike
                                         select r.Id).Count(),
                            ViewCount = (from v in _dbContext.Set<ViewMonitoring>() 
                                         where v.IdeaId == i.Id 
                                         select v.ViewCounts).Sum()
                        };
            return await query.ToListAsync();
        }
    }
}
