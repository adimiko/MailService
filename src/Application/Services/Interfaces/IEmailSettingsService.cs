using Application.DTOs;
using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IEmailSettingsService : IService
    {
        public Task<EmailSettingsDetailsDto> GetAsync(Guid id);
        public Task<IEnumerable<EmailSettingsDto>> BrowseAsync();
        public Task CreateAsync(Guid id, string smtpHost, int smtpPort,string displayName, string email, string password);
        public Task UpdateAsync(Guid id, string smtpHost, int smtpPort,string displayName, string email, string password);
        public Task DeleteAsync(Guid id);
    }
}
