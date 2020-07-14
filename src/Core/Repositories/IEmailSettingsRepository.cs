using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain.Entities;
using Core.Domain.ValueObjects;

namespace Core.Repositories
{
    public interface IEmailSettingsRepository
    {
        Task<EmailSettings> GetAsync(Guid id);
        Task<EmailSettings> GetAsync(Email email);
        Task<IEnumerable<EmailSettings>> BrowseAsync();
        Task UpdateAsync(EmailSettings emailSettings);
        Task AddAsync(EmailSettings emailSettings);
        Task RemoveAsync(EmailSettings emailSettings);
    }
}