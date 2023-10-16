using BuildMe.Application.Configurations;
using BuildMe.Application.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Mail;

namespace BuildMe.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly string _smtpServer;
        private readonly string _smtpPort;
        private readonly string _username;
        private readonly string _password;
        private readonly ILogger<EmailService> _logger;
        private readonly IApplicationSettings _appSettings;

        public EmailService(ILogger<EmailService> logger, IApplicationSettings appSettings)
        {
            _logger = logger;
            _appSettings = appSettings;

            _smtpServer = _appSettings.SMTPSettings.Server;
            _smtpPort = _appSettings.SMTPSettings.Port;
            _username = _appSettings.SMTPSettings.Username;
            _password = _appSettings.SMTPSettings.Password;
        }

        public async Task SendEmailAsync(string recipient, string subject, string body)
        {
            try
            {
                int.TryParse(_smtpPort, out int port);

                using (var message = new MailMessage())
                {
                    message.To.Add(recipient);
                    message.Subject = subject;
                    message.Body = body;
                    message.From = new MailAddress(_username);

                    using (var client = new SmtpClient(_smtpServer, port))
                    {
                        client.EnableSsl = true;
                        client.Credentials = new NetworkCredential(_username, _password);
                        await client.SendMailAsync(message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
