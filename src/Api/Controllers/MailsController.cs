using System;
using System.Threading.Tasks;

using Application.Commands.Mails;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    public class MailsController : Controller
    {
        private readonly IMailService _mailService; 

        public MailsController(IMailService mailService)
        {
            _mailService = mailService;
        }
        [HttpGet]
        public async Task<IActionResult> Browse()
            => Json(await _mailService.BrowseAsync());


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SendMail command)
        {
            command.Id = Guid.NewGuid();
            
            await _mailService.SendAsync
            (
               command.Id,
               command.From,
               command.To,
               command.Subject,
               command.Body 
            );

            return Created($"/mails/{command.Id}",command.Id);
        }
        
    }
}