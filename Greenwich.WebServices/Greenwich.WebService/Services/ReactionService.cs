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
                CreatedDate = DateTime.UtcNow,
                IsLike = true
            };
            await _unitOfWork.ReactionRepository.InsertAsync(reactionDTO);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> DoUnlike(DoUnlikeRequest request)
        {
            var reactionDTO = new Reaction
            {
                UserId = request.UserId,
                IdeaId = request.IdeaId,
                CreatedDate = DateTime.UtcNow,
                IsUnlike = true
            };
            await _unitOfWork.ReactionRepository.InsertAsync(reactionDTO);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<int> GetLikeCount(int ideaId)
        {
            var reactions = await _unitOfWork.ReactionRepository.GetAsync(x =>
            x.IdeaId == ideaId && x.IsLike == true);
            return reactions.Count();
        }

        public async Task<int> GetUnLikeCount(int ideaId)
        {
            var reactions = await _unitOfWork.ReactionRepository.GetAsync(x =>
            x.IdeaId == ideaId && x.IsUnlike == true);
            return reactions.Count();
        }
    }
}
