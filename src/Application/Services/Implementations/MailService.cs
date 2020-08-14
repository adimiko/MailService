using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Services.Interfaces;
using AutoMapper;
using Core.Domain.Entities;
using Core.Domain.ValueObjects;
using Core.Repositories;

namespace Application.Services.Implementations
{
    public class MailService : IMailService
    {
        private readonly IMailRepository _mailRepository;
        private readonly IEmailSettingsRepository _emailSettingsRepository;
        private readonly IMailKitProvider _mailKitProvider;
        private readonly IEncrypterProvider _encrypterProvider;
        private readonly IMapper _mapper;
        
        public MailService(IMailRepository mailRepository, IEmailSettingsRepository emailSettingsRepository, IMailKitProvider mailKitProvider, IEncrypterProvider encrypterProvider, IMapper mapper)
        {
            _mailRepository = mailRepository;
            _emailSettingsRepository = emailSettingsRepository;
            _mailKitProvider = mailKitProvider;
            _encrypterProvider = encrypterProvider;
            _mapper = mapper;
        }

        public async Task<Mail> GetAsync(Guid id)
            => await _mailRepository.GetAsync(id);
        public async Task<IEnumerable<MailDto>> BrowseAsync()
            => _mapper.Map<IEnumerable<MailDto>>(await _mailRepository.BrowseAsync());

        public async Task SendAsync(Guid id, string from, string to, string subject, string body)
        {
            
            var emailSettings = await _emailSettingsRepository.GetAsync(Email.Create(from));

            if(emailSettings == null)
            {
                throw new Exception($"The configuration for this email {from} does not exist.");
            }

            var decryptedPassword = await _encrypterProvider.DecryptAsync(emailSettings.Password);

            await _mailKitProvider.SendAsync(emailSettings.SmtpHost, emailSettings.SmtpPort, emailSettings.DisplayName,
                emailSettings.Email.Value, decryptedPassword, to, subject, body);

            var mail = new Mail(id, Email.Create(from), Email.Create(to), subject,body);
            await _mailRepository.AddAsync(mail);
        }
    }
}