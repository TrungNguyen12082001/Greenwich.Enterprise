using Greenwich.Models.Requests;
using Greenwich.Models.Settings;
using Greenwich.WebService.IServices;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Greenwich.WebService.Services
{
    public class EmailService : IEmailService
    {
        private SendGridClient _sendGridClient;
        private readonly IOptionsMonitor<ISendGridSetting> _config;

        public EmailService(IOptionsMonitor<SendGridSetting> config)
        { 
            _config = config;
            _sendGridClient = new SendGridClient(_config.CurrentValue.ApiKey);
        }

        public async Task<Response> SendSingleEmail(SingleEmailRequest model)
        {
            var msg = MailHelper.CreateSingleEmail(
                new EmailAddress(_config.CurrentValue.SendFrom),
                new EmailAddress(model.ToEmail),
                model.Subject,
                model.PlaintextContent,
                model.HtmlContent);
            var response = await _sendGridClient.SendEmailAsync(msg);
            return response;
        }
    }
}
