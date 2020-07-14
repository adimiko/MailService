using System;

namespace Application.Commands.EmailSettings
{
    public class CreateEmailSettings
    {
        public Guid Id {get; set;}
        public string SmtpHost {get; set;}
        public int SmtpPort {get; set;}
        public string DisplayName {get; set;}
        public string Email {get; set;}
        public string Password {get; set;} 
    }
}