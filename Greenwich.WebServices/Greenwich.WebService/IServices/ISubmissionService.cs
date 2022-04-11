using Greenwich.EntityFramework.Entities;
using Greenwich.Models.Requests;

namespace Greenwich.WebService.IServices
{
    public interface ISubmissionService
    {
        Task<IEnumerable<Submission>> GetSubmissionsAsync();
        Task<bool> CreateSubmission(CreateSubmissionRequest request);
    }
}
