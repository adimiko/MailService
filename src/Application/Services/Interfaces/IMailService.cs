using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain.Entities;

namespace Application.Services.Interfaces
{
    public interface IMailService
    {
        Task<Mail> GetAsync(Guid id);
        Task<IEnumerable<Mail>> BrowseAsync();
        Task SendAsync(Guid id,string from, string to, string subject,string body);
    }
}