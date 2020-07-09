using System;

namespace Application.Commands.EmailSettings
{
    public class CreateEmailSettings
    {
        public Guid Id {get; set;}
        public string Host {get; set;}
        public int Port {get; set;}
        public string Username {get; set;}
        public string Password {get; set;}
    }
}