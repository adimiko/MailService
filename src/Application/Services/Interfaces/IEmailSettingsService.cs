using Application.DTOs;
using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IEmailSettingsService
    {
        public Task<EmailSettingsDetailsDto> GetAsync(Guid id);
        public Task<IEnumerable<EmailSettingsDto>> BrowseAsync();
        public Task CreateAsync(Guid id, string host, int port, string username, string password);
        public Task UpdateAsync(Guid id, string host, int port, string username, string password);
        public Task DeleteAsync(Guid id);
    }
}
