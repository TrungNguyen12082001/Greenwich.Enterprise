using Greenwich.DataPersistence.Common;
using Greenwich.EntityFramework.Entities;
using Greenwich.Models.Requests;
using Greenwich.WebService.IServices;
using Microsoft.Extensions.Logging;

namespace Greenwich.WebService.Services
{
    public class SubmissionService : ISubmissionService
    {
        private readonly IGEWUnitOfWork _unitOfWork;
        private ILogger<SubmissionService> _logger;

        public SubmissionService(IGEWUnitOfWork unitOfWork, ILogger<SubmissionService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<bool> CreateSubmission(CreateSubmissionRequest request)
        {
            try
            {
                var submissionDTO = new Submission { 
                    Name = request.Name,
                    Description = request.Description,
                    ClosureDate = request.ClosureDate,
                    FinalClosureDate = request.FinalClosureDate
                };

                await _unitOfWork.SubmissionRepository.InsertAsync(submissionDTO);
                return await _unitOfWork.SaveChangeAsync() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error while CreateSubmission", ex);
            }
            return false;
        }

        public async Task<IEnumerable<Submission>> GetSubmissionsAsync()
        {            
            try
            {
                IEnumerable<Submission>  modelList = await _unitOfWork.SubmissionRepository.GetAsync();
                return modelList;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error while GetSubmissionsAsync", ex);
            }

            return new List<Submission>();
        }
    }
}
