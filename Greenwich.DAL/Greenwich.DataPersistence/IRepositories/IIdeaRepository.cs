using Greenwich.DataPersistence.Common;
using Greenwich.EntityFramework.Entities;
using Greenwich.Models.Requests;
using Greenwich.Models.Responses;

namespace Greenwich.DataPersistence.IRepositories
{
    public interface IIdeaRepository : IRepository<Idea>
    {
        Task<IEnumerable<GetIdeasResponse>> GetIdeasBySubmissionId(int submissionId);
    }
}
