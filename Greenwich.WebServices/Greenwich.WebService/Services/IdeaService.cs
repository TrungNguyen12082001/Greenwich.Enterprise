using Greenwich.DataPersistence.Common;
using Greenwich.EntityFramework.Entities;
using Greenwich.Models.Requests;
using Greenwich.Models.Responses;
using Greenwich.WebService.IServices;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenwich.WebService.Services
{
    public class IdeaService : IIdeaService
    {
        private readonly IGEWUnitOfWork _unitOfWork;
        private ILogger<IdeaService> _logger;

        public IdeaService(IGEWUnitOfWork unitOfWork, ILogger<IdeaService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<bool> CreateIdeaAsync(CreateIdeaRequest request)
        {
            try
            {
                var ideaDTO = new Idea { 
                    Title = request.Title,
                    Description = request.Description,
                    Content = request.Content,                    
                    UserId = request.UserId,                    
                    CategoryId = request.CategoryId,
                    CreatedDate = DateTime.UtcNow,
                    SubmissionId = request.SubmissionId
                };

                await _unitOfWork.IdeaRepository.InsertAsync(ideaDTO);
                return await _unitOfWork.SaveChangeAsync() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error while CreateIdeaAsync", ex);
            }
            return false;
        }

        public async Task<IEnumerable<GetIdeasResponse>> GetALlIdeasAsync(int submissionId)
        {
            IEnumerable<GetIdeasResponse> modelList = null;

            try
            {
                modelList = await _unitOfWork.IdeaRepository.GetIdeasBySubmissionId(submissionId);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error while GetALlIdeasAsync", ex);
            }

            return modelList;
        }

        public async Task<Idea> GetIdeaByIdAsync(int id)
        {
            return await _unitOfWork.IdeaRepository.GetByIdAsync(id);
        }
    }
}
