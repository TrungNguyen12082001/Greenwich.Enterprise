using Greenwich.Models.Requests;

namespace Greenwich.WebService.IServices
{
    public interface IViewMonitoringService
    {
        Task<bool> CreateView(CreateViewRequest model);
        Task<int> GetViewCountByIdeadId(int ideaId);
    }
}
