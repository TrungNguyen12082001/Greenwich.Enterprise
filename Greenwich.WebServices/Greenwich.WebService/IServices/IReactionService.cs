using Greenwich.Models.Requests;

namespace Greenwich.WebService.IServices
{
    public interface IReactionService
    {        
        Task<bool> DoLike(DoLikeRequest request);
        Task<bool> DoUnlike(DoUnlikeRequest request);
        Task<int> GetLikeCount(int ideaId);

        Task<int> GetUnLikeCount(int ideaId);
    }
}
