using System.Threading.Tasks;
using Application.Services.Interfaces;
using Infrastructure.Settings;
using NETCore.Encrypt;

namespace Infrastructure.Services
{
    public class AesEncrypterProvider : IEncrypterProvider
    {
        private readonly EncryptionSettings _encryptionSettings;
        public AesEncrypterProvider(EncryptionSettings encrptionSettings)
            => _encryptionSettings = encrptionSettings;

        public async Task<string> EncryptAsync(string value)
            => await Task.FromResult(EncryptProvider.AESEncrypt(value, _encryptionSettings.Key));

        public async Task<string> DecryptAsync(string value)
            => await Task.FromResult(EncryptProvider.AESDecrypt(value, _encryptionSettings.Key));
    }
}