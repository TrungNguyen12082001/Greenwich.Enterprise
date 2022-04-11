using Greenwich.DataPersistence.Common;
using Greenwich.EntityFramework.Entities;
using Greenwich.Models.Requests;
using Greenwich.WebService.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenwich.WebService.Services
{
    public class ReplyService : IReplyService
    {
        private readonly IGEWUnitOfWork _unitOfWork;

        public ReplyService(IGEWUnitOfWork unitOfWork)
        { 
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateReplyAsync(CreateReplyRequest request)
        {
            var replyDTO = new Reply
            {
                CommentId = request.CommentId,
                Content = request.Content,
                UserId = request.UserId,
                CreatedDate = DateTime.UtcNow
            };

            await _unitOfWork.ReplyRepository.InsertAsync(replyDTO);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<IEnumerable<Reply>> GetRepliesAsync(int commentId)
        {
            var modelList = await _unitOfWork.ReplyRepository.GetAsync(x => x.CommentId == commentId);
            return modelList;
        }
    }
}
