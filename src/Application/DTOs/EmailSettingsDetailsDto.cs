using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class EmailSettingsDetailsDto
    {
        public Guid Id {get; protected set;}
        public string SmtpHost {get; protected set;}
        public int SmtpPort {get; protected set;}
        public string DisplayName {get; protected set;}
        public string Email {get; protected set;}
    }
}
