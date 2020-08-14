using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Attachments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    public class AttachmentsController : Controller
    {

        public AttachmentsController()
        {

        }

        [HttpPost]
        public async Task<IActionResult> Post(List<IFormFile> files)
        {
            

        }
    }
}