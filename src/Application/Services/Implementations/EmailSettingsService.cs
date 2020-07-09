using Application.DTOs;
using Application.Services.Interfaces;
using AutoMapper;
using Core.Domain.Entities;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implementations
{
    public class EmailSettingsService : IEmailSettingsService
    {
        private readonly IEmailSettingsRepository _emailSettingsRepository;
        private readonly IMapper _mapper;

        public EmailSettingsService(IEmailSettingsRepository emailSettingsRepository, IMapper mapper)
        {
            _emailSettingsRepository = emailSettingsRepository;
            _mapper = mapper;
        }

        public async Task<EmailSettingsDetailsDto> GetAsync(Guid id)
            => _mapper.Map<EmailSettingsDetailsDto>(await _emailSettingsRepository.GetAsync(id));

        public async Task<IEnumerable<EmailSettingsDto>> BrowseAsync()
            => _mapper.Map<IEnumerable<EmailSettingsDto>>(await _emailSettingsRepository.BrowseAsync());

        public async Task CreateAsync(Guid id, string host, int port, string username, string password)
        {
            var user = await _emailSettingsRepository.GetAsync(username);
           
            if(user != null)
            {
               throw new Exception("Username already exists.");
            }

            user = new EmailSettings(id,host,port,username,password);
            await _emailSettingsRepository.AddAsync(user);
        }

        public async Task UpdateAsync(Guid id, string host, int port, string username, string password)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await _emailSettingsRepository.GetAsync(id);

            if(user == null) throw new Exception("User does not exist");

            await _emailSettingsRepository.RemoveAsync(user);
        }
    }
}
