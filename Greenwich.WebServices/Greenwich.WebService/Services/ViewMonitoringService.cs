using Greenwich.DataPersistence.Common;
using Greenwich.Models.Requests;
using Greenwich.WebService.IServices;

namespace Greenwich.WebService.Services
{
    public class ViewMonitoringService : IViewMonitoringService
    {
        private readonly IGEWUnitOfWork _unitOfWork;

        public ViewMonitoringService(IGEWUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateView(CreateViewRequest model)
        {
            var viewDTO = await _unitOfWork.ViewMonitoringRepository.GetOneAsync(x => 
            x.IdeaId == model.IdeaId && 
            x.UserId == model.UserId);
            bool isAddNew = false;

            if (viewDTO == null)
            {
                viewDTO = new EntityFramework.Entities.ViewMonitoring
                {
                    IdeaId = model.IdeaId,
                    UserId = model.UserId,
                    ViewCounts = 1
                };
                isAddNew = true;
            }
            else
            {
                viewDTO.ViewCounts += 1;
            }

            if (isAddNew)
                await _unitOfWork.ViewMonitoringRepository.InsertAsync(viewDTO);
            else
                _unitOfWork.ViewMonitoringRepository.Update(viewDTO);

            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<int> GetViewCountByIdeadId(int ideaId)
        {
            var model = await _unitOfWork.ViewMonitoringRepository.GetOneAsync(x => x.IdeaId.Equals(ideaId));
            return model.ViewCounts;
        }
    }
}
