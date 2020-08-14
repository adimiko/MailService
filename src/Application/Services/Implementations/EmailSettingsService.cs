using Application.DTOs;
using Application.Services.Interfaces;
using AutoMapper;
using Core.Domain.Entities;
using Core.Domain.ValueObjects;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Implementations
{
    public class EmailSettingsService : IEmailSettingsService
    {
        private readonly IEmailSettingsRepository _emailSettingsRepository;
        private readonly IMailKitProvider _mailKitProvider;
        private readonly IEncrypterProvider _encrypterProvider;
        private readonly IMapper _mapper;

        public EmailSettingsService(IEmailSettingsRepository emailSettingsRepository,IMailKitProvider mailKitProvider,IEncrypterProvider encrypterProvider, IMapper mapper)
        {
            _emailSettingsRepository = emailSettingsRepository;
            _mailKitProvider = mailKitProvider;
            _encrypterProvider = encrypterProvider;
            _mapper = mapper;
        }

        public async Task<EmailSettingsDetailsDto> GetAsync(Guid id)
            => _mapper.Map<EmailSettingsDetailsDto>(await _emailSettingsRepository.GetAsync(id));

        public async Task<IEnumerable<EmailSettingsDto>> BrowseAsync()
            => _mapper.Map<IEnumerable<EmailSettingsDto>>(await _emailSettingsRepository.BrowseAsync());

        public async Task CreateAsync(Guid id, string smtpHost, int smtpPort,string displayName, string email, string password)
        {
            var emailSettings = await _emailSettingsRepository.GetAsync(Email.Create(email));
            if(emailSettings != null) throw new Exception("Username already exists.");

            var encryptedPassword = await _encrypterProvider.EncryptAsync(password);

            emailSettings = new EmailSettings(id, smtpHost, smtpPort, displayName, Email.Create(email), encryptedPassword);

            await _mailKitProvider.TestConnectionConfiguration(smtpHost, smtpPort, email, password);
            await _emailSettingsRepository.AddAsync(emailSettings);
        }

        public async Task UpdateAsync(Guid id, string smtpHost, int smtpPort,string displayName, string email, string password)
        {
            var emailSettings = await _emailSettingsRepository.GetAsync(Email.Create(email));
            if(emailSettings == null) throw new Exception("Email settings does not exist");

            await _mailKitProvider.TestConnectionConfiguration(smtpHost, smtpPort, email, password);

            emailSettings.SetSmtpHost(smtpHost);
            emailSettings.SetSmtpPort(smtpPort);
            emailSettings.SetDisplayName(displayName);
            emailSettings.SetEmail(Email.Create(email));

            var encryptedPassword = await _encrypterProvider.EncryptAsync(password);
            emailSettings.SetPassword(encryptedPassword);
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await _emailSettingsRepository.GetAsync(id);

            if(user == null) throw new Exception("Email settings does not exist");

            await _emailSettingsRepository.RemoveAsync(user);
        }
    }
}
