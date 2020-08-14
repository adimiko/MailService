using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IEncrypterProvider
    {
        Task<string> EncryptAsync(string value);
        Task<string> DecryptAsync(string value);
    }
}