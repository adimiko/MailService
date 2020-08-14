using System;

namespace Application.DTOs
{
    public class MailDto
    {
        public Guid Id {get; set;}
        public string From {get; set;}
        public string To {get; set;}
        public string Subject {get; set;}
        public DateTime SentAt {get; set;}
    }
}