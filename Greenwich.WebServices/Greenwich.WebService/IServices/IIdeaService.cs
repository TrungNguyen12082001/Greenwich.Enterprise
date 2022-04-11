using Greenwich.EntityFramework.Entities;
using Greenwich.Models.Requests;
using Greenwich.Models.Responses;

namespace Greenwich.WebService.IServices
{
    public interface IIdeaService
    {
        Task<IEnumerable<GetIdeasResponse>> GetALlIdeasAsync(int submissionId);
        Task<bool> CreateIdeaAsync(CreateIdeaRequest request);

        Task<Idea> GetIdeaByIdAsync(int id);
    }
}
