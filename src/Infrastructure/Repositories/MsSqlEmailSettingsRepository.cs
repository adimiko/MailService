using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Entities;
using Core.Domain.ValueObjects;
using Core.Repositories;
using Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MsSqlEmailSettingsRepository : IEmailSettingsRepository
    {
        private readonly MailServiceContext _context;

        public MsSqlEmailSettingsRepository(MailServiceContext context)
        {
            _context = context;
        }
        public async Task<EmailSettings> GetAsync(Guid id)
            => await _context.EmailSettings.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<EmailSettings> GetAsync(Email email)
            => await _context.EmailSettings.SingleOrDefaultAsync(x => x.Email.Value == email.Value);

        public async Task<IEnumerable<EmailSettings>> BrowseAsync()
            => await _context.EmailSettings.ToListAsync();
        public async Task AddAsync(EmailSettings emailSettings)
        {
            await _context.EmailSettings.AddAsync(emailSettings);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(EmailSettings emailSettings)
        {
            _context.EmailSettings.Update(emailSettings);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveAsync(EmailSettings emailSettings)
        {
            var user = await GetAsync(emailSettings.Id);
            _context.Remove(user);
            await _context.SaveChangesAsync();
        }


    }
}