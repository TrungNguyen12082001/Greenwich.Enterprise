using Greenwich.EntityFramework.Entities;
using Greenwich.Models.Requests;

namespace Greenwich.WebService.IServices
{
    public interface ICommentService
    {
        Task<bool> CreateCommentAsync(CreateCommentRequest request);
        Task<IEnumerable<Comment>> GetCommentsAsync(int ideaId);
    }
}
