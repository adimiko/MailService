using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IMailKitProvider
    {
        Task SendAsync(string from, string to, string subject, string body);
        Task TestConnectionConfiguration(string host, int port, string username, string password);
    }
}