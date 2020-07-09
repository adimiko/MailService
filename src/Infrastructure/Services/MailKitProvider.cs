using System.Security.Authentication;
using System.Threading.Tasks;
using Application.Services.Interfaces;
using Core.Repositories;
using Infrastructure.MimeKit;
using MailKit.Net.Smtp;
using MimeKit;

namespace Infrastructure.Services
{
    public class MailKitProvider : IMailKitProvider
    {
        private readonly IMailKitConfig _mailKitConfig;
        private readonly IEmailSettingsRepository _emailSettingsRepository;
        
        public MailKitProvider(IMailKitConfig mailKitConfig, IEmailSettingsRepository emailSettingsRepository)
        {
            _mailKitConfig = mailKitConfig;
            _emailSettingsRepository = emailSettingsRepository;
        }

        public async Task SendAsync(string from, string to, string subject, string body)
        {
            MimeMessage message = new MimeMessage();

            var emailSettings = await _emailSettingsRepository.GetAsync(from);

            message.From.Add(new MailboxAddress(emailSettings.Username, emailSettings.Username));
            message.To.Add(MailboxAddress.Parse(to));
            message.Subject = subject;
            message.Body = new TextPart("plain")
            {
                Text = body
            };

            using(var client = new SmtpClient())
            {
                //poprawić walidację
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                await client.ConnectAsync(emailSettings.Host, emailSettings.Port);

                await client.AuthenticateAsync(emailSettings.Username, emailSettings.Password);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }

            await Task.CompletedTask;
        }
    }
}