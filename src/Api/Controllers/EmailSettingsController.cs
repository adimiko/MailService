using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.EmailSettings;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("email-settings")]
    public class EmailSettingsController : Controller
    {
        private readonly IEmailSettingsService _emailSettingsService;

        public EmailSettingsController(IEmailSettingsService emailSettingsService)
        {
            _emailSettingsService = emailSettingsService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
         {
            var emailSettings = await _emailSettingsService.GetAsync(id);
            if(emailSettings == null) return NotFound();

            return Json(emailSettings);
         }

        [HttpGet]
        public async Task<IActionResult> Browse()
            => Json(await _emailSettingsService.BrowseAsync());

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateEmailSettings command)
        {
            command.Id = Guid.NewGuid();
            await _emailSettingsService.CreateAsync(command.Id, command.SmtpHost, command.SmtpPort, command.DisplayName, command.Email, command.Password);
            return Created($"/email-settings/{command.Id}",command.Id);
        }

        // PUT: api/EmailSettings/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _emailSettingsService.DeleteAsync(id);
            return NoContent();
        }
    }
}
