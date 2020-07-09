using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Entities;
using Core.Repositories;

namespace Infrastructure.Repositories
{
    public class EmailSettingsRepository : IEmailSettingsRepository
    {
        private static ISet<EmailSettings> _emailSettings = new HashSet<EmailSettings>()
        {
            
        };
        public async Task<EmailSettings> GetAsync(Guid id)
            => await Task.FromResult(_emailSettings.Where(x => x.Id == id).SingleOrDefault());

        public async Task<EmailSettings> GetAsync(string username)
            => await Task.FromResult(_emailSettings.Where(x => x.Username == username).SingleOrDefault());
        public async Task<IEnumerable<EmailSettings>> BrowseAsync()
            => await Task.FromResult(_emailSettings.AsEnumerable());

        public async Task UpdateAsync(EmailSettings emailSettings)
        {
            await Task.CompletedTask;
        }

        public async Task AddAsync(EmailSettings emailSettings)
        {
            _emailSettings.Add(emailSettings);
            await Task.CompletedTask;
        }

        public async Task RemoveAsync(EmailSettings emailSettings)
        {
            _emailSettings.Remove(emailSettings);
            await Task.CompletedTask;
        }


    }
}