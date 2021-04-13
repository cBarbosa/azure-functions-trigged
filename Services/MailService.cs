using functions.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace functions.Services
{
    class MailService : IMailService
    {
        private readonly MailServiceSettings _mailServiceSettings;
        private readonly ILogger<MailService> _log;

        public MailService(MailServiceSettings mailServiceSettings, ILogger<MailService> log)
        {
            _mailServiceSettings = mailServiceSettings;
            _log = log;
        }

        public async Task SendInvitation(string emailAddress)
        {
            _log.LogInformation($"Email sent to: {emailAddress} from: {_mailServiceSettings.SMTPFromAddress}");
        }
    }
}