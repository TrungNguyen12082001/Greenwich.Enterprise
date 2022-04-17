using Greenwich.Models.Requests;
using SendGrid;

namespace Greenwich.WebService.IServices
{
    public interface IEmailService
    {
        Task<Response> SendSingleEmail(SingleEmailRequest model);
    }
}
