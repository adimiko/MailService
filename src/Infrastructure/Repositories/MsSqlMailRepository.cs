using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain.Entities;
using Core.Repositories;
using Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MsSqlMailRepository : IMailRepository
    {
        private readonly MailServiceContext _context;
        
        public MsSqlMailRepository(MailServiceContext context)
        {
            _context = context;
        }
        public async Task<Mail> GetAsync(Guid id)
            => await _context.Mails.SingleOrDefaultAsync(x => x.Id == id);
        public async Task<IEnumerable<Mail>> BrowseAsync()
            => await _context.Mails.ToListAsync();
        public async Task AddAsync(Mail mail)
        {
            await _context.Mails.AddAsync(mail);
            await _context.SaveChangesAsync();
        }
        
        public async Task RemoveAsync(Mail mail)
        {
            _context.Mails.Update(mail);
            await _context.SaveChangesAsync();
        }
    }
}