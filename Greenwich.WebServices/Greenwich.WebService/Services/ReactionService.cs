using Greenwich.DataPersistence.Common;
using Greenwich.EntityFramework.Entities;
using Greenwich.Models.Requests;
using Greenwich.WebService.IServices;

namespace Greenwich.WebService.Services
{
    public class ReactionService : IReactionService
    {
        private readonly IGEWUnitOfWork _unitOfWork;
        public ReactionService(IGEWUnitOfWork unitOfWork)
        { 
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> DoLike(DoLikeRequest request)
        {
            var reactionDTO = new Reaction { 
                UserId = request.UserId,
                IdeaId = request.IdeaId,
                CreatedDate = DateTime.UtcNow
            };
            await _unitOfWork.ReactionRepository.InsertAsync(reactionDTO);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> DoUnlike(DoUnlikeRequest request)
        {
            var reactionDTO = await _unitOfWork.ReactionRepository.GetOneAsync(x => 
            x.IdeaId == request.IdeaId && 
            x.UserId == request.UserId);
            if (reactionDTO != null)
            {
                _unitOfWork.ReactionRepository.Delete(reactionDTO);
                return await _unitOfWork.SaveChangeAsync() > 0;
            }

            return false;
        }

        public async Task<int> GetLikeCount(int ideaId)
        {
            var reactions = await _unitOfWork.ReactionRepository.GetAsync(x =>
            x.IdeaId == ideaId);
            return reactions.Count();
        }
    }
}
