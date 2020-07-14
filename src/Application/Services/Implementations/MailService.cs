using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Services.Interfaces;
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
        
        public MailService(IMailRepository mailRepository, IEmailSettingsRepository emailSettingsRepository, IMailKitProvider mailKitProvider)
        {
            _mailRepository = mailRepository;
            _emailSettingsRepository = emailSettingsRepository;
            _mailKitProvider = mailKitProvider;
        }

        public async Task<Mail> GetAsync(Guid id)
            => await _mailRepository.GetAsync(id);
        public async Task<IEnumerable<Mail>> BrowseAsync()
            => await _mailRepository.BrowseAsync();

        public async Task SendAsync(Guid id, string from, string to, string subject, string body)
        {
            
            var email = await _emailSettingsRepository.GetAsync(Email.Create(from));

            if(email == null)
            {
                throw new Exception($"The configuration for this email {from} does not exist.");
            }

            await _mailKitProvider.SendAsync(from,to,subject,body);

            var mail = new Mail(id, Email.Create(from), Email.Create(to), subject,body);
            await _mailRepository.AddAsync(mail);
        }
    }
}