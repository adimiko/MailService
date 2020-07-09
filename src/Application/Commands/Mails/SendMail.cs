using System;

namespace Application.Commands.Mails
{
    public class SendMail
    {
        public Guid Id {get; set;}
        public string From {get; set;}
        public string To {get; set;}
        public string Subject  {get; set;}
        public string Body  {get; set;}
    }
}