using Greenwich.EntityFramework.Entities;
using Greenwich.Models.Requests;

namespace Greenwich.WebService.IServices
{
    public interface IReplyService
    {
        Task<bool> CreateReplyAsync(CreateReplyRequest request);

        Task<IEnumerable<Reply>> GetRepliesAsync(int commentId);
    }
}
