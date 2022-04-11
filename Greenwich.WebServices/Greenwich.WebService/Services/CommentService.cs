using Greenwich.DataPersistence.Common;
using Greenwich.EntityFramework.Entities;
using Greenwich.Models.Requests;
using Greenwich.WebService.IServices;

namespace Greenwich.WebService.Services
{
    public class CommentService : ICommentService
    {
        private readonly IGEWUnitOfWork _unitOfWork;

        public CommentService(IGEWUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateCommentAsync(CreateCommentRequest request)
        {
            var commentDTO = new Comment
            {
                IdeaId = request.IdeaId,
                Content = request.Content,
                UserId = request.UserId,
                CreatedDate = DateTime.UtcNow
            };

            await _unitOfWork.CommentRepository.InsertAsync(commentDTO);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<IEnumerable<Comment>> GetCommentsAsync(int ideaId)
        {
            var modelList = await _unitOfWork.CommentRepository.GetAsync(x => x.IdeaId == ideaId);
            return modelList;
        }
    }
}
