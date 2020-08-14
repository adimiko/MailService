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
        public MailKitProvider()
        {

        }

        public async Task SendAsync(string smtpHost, int smtpPort,string displayName, string email, string password, string to, string subject, string body)
        {
            MimeMessage message = new MimeMessage();

            message.From.Add(new MailboxAddress(displayName, email));
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
                await client.ConnectAsync(smtpHost, smtpPort);

                await client.AuthenticateAsync(email, password);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
            public async Task TestConnectionConfiguration(string host, int port, string email, string password)
            {
                using(var client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    await client.ConnectAsync(host, port);
                    await client.AuthenticateAsync(email, password);
                    await client.DisconnectAsync(true);
                }
            }

    }
}      
