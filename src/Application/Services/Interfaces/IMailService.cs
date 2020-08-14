using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs;
using Core.Domain.Entities;

namespace Application.Services.Interfaces
{
    public interface IMailService : IService
    {
        Task<Mail> GetAsync(Guid id);
        Task<IEnumerable<MailDto>> BrowseAsync();
        Task SendAsync(Guid id,string from, string to, string subject,string body);
    }
}