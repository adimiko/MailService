using System;
using System.Collections.Generic;
using System.IO;
using Core.Domain.ValueObjects;

namespace Core.Domain.Entities
{
    public class Mail
    {
        private List<string> _attachments  = new List<string>();
        public Guid Id {get; protected set;}
        public Email From {get; protected set;}
        public Email To {get; protected set;}
        public string Subject {get; protected set;}
        public string Body {get; protected set;}
        public IEnumerable<string> Attachments => _attachments;
        public DateTime SentAt {get; protected set;}

        protected Mail() {}

        public Mail(Guid id,Email from, Email to, string subject, string body)
        {
            SetId(id);
            SetFrom(from);
            SetTo(to);
            SetSubject(subject);
            SetBody(body);
            SentAt = DateTime.UtcNow;
        }

        private void SetId(Guid id)
            => _= id == Guid.Empty ? throw new Exception("Id cannot be null.") : Id = id;

        private void SetFrom(Email from)
            => From = from ?? throw new ArgumentNullException();

        private void SetTo(Email to)
            => To = to ?? throw new ArgumentNullException();

        private void SetSubject(string subject)
            => _= string.IsNullOrWhiteSpace(subject) ?
            throw new Exception("Subject cannot be null or white space.") :
            Subject = subject;
        private void SetBody(string body)
            => _= string.IsNullOrWhiteSpace(body) ?
            throw new Exception("Body cannot be null or white space.") :
            Body = body;
    }
}