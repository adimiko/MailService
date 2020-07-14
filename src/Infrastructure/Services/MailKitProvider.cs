using System.Security.Authentication;
using System.Threading.Tasks;
using Application.Services.Interfaces;
using Core.Domain.ValueObjects;
using Core.Repositories;
using MailKit.Net.Smtp;
using MimeKit;

namespace Infrastructure.Services
{
    public class MailKitProvider : IMailKitProvider
    {
        
        private readonly IEmailSettingsRepository _emailSettingsRepository;
        
        public MailKitProvider(IEmailSettingsRepository emailSettingsRepository)
        {
            _emailSettingsRepository = emailSettingsRepository;
        }

        public async Task SendAsync(string from, string to, string subject, string body)
        {
            MimeMessage message = new MimeMessage();

            var emailSettings = await _emailSettingsRepository.GetAsync(Email.Create(from));

            message.From.Add(new MailboxAddress(emailSettings.DisplayName, emailSettings.Email.ToString()));
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
                await client.ConnectAsync(emailSettings.SmtpHost, emailSettings.SmtpPort);

                await client.AuthenticateAsync(emailSettings.Email.ToString(), emailSettings.Password);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
            public async Task TestConnectionConfiguration(string host, int port, string username, string password)
            {
                using(var client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    await client.ConnectAsync(host, port);
                    await client.AuthenticateAsync(username, password);
                    await client.DisconnectAsync(true);
                }
            }

    }
}      
