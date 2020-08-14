using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain.Entities;

namespace Core.Repositories
{
    public interface IMailRepository : IRepository
    {
        Task<Mail> GetAsync(Guid id);
        Task<IEnumerable<Mail>> BrowseAsync();
        Task AddAsync(Mail mail);
        Task RemoveAsync(Mail mail);
    }
}