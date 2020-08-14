using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IMailKitProvider : IService
    {
        Task SendAsync(string smtpHost, int smtpPort,string displayName, string email, string password, string to, string subject, string body);
        Task TestConnectionConfiguration(string host, int port, string email, string password);
    }
}