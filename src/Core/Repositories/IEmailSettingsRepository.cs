using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain.Entities;

namespace Core.Repositories
{
    public interface IEmailSettingsRepository
    {
        Task<EmailSettings> GetAsync(Guid id);
        Task<EmailSettings> GetAsync(string username);
        Task<IEnumerable<EmailSettings>> BrowseAsync();
        Task UpdateAsync(EmailSettings emailSettings);
        Task AddAsync(EmailSettings emailSettings);
        Task RemoveAsync(EmailSettings emailSettings);
    }
}