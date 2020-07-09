using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Entities;
using Core.Repositories;

namespace Infrastructure.Repositories
{
    public class MailRepository : IMailRepository
    {
        private static ISet<Mail> _mails = new HashSet<Mail>()
        {

        };
        public async Task<Mail> GetAsync(Guid id)
            => await Task.FromResult(_mails.Where(x => x.Id == id).SingleOrDefault());
        public async Task<IEnumerable<Mail>> BrowseAsync()
            => await Task.FromResult(_mails.AsEnumerable());
        public async Task AddAsync(Mail mail)
        {
            _mails.Add(mail);
            await Task.CompletedTask;
        }

        public async Task RemoveAsync(Mail mail)
        {
            _mails.Remove(mail);
            await Task.CompletedTask;
        }
    }
}