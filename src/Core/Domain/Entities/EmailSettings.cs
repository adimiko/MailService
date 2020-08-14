using System;
using Core.Domain.ValueObjects;

namespace Core.Domain.Entities
{
    public class EmailSettings
    {
        public Guid Id {get; protected set;}
        public string SmtpHost {get; protected set;}
        public int SmtpPort {get; protected set;}
        public string DisplayName {get; protected set;}
        public Email Email {get; protected set;}
        public string Password {get; protected set;}


        protected EmailSettings() {}
        public EmailSettings(Guid id, string smtpHost, int smtpPort, string displayName, Email email, string password)
        {
            SetId(id);
            SetSmtpHost(smtpHost);
            SetSmtpPort(smtpPort);
            SetDisplayName(displayName);
            SetEmail(email);
            SetPassword(password);
        }

        private void SetId(Guid id)
            => _= id == Guid.Empty ? throw new Exception("Id cannot be empty") : Id = id;
        public void SetSmtpHost(string smtpHost)
        {
            if(string.IsNullOrWhiteSpace(smtpHost))
            {
                throw new Exception("Smtp host cannot be null or white space.");
            }

            if(SmtpHost == smtpHost) return;

            SmtpHost = smtpHost;
        }

        public void SetSmtpPort(int smtpPort)
            => _= smtpPort <= 0 ? throw new Exception("Smtp port cannot be equel to or less than zero.") : SmtpPort = smtpPort;
        
        public void SetDisplayName(string displayName)
            => _= string.IsNullOrWhiteSpace(displayName) ? throw new Exception("Display name cannot be null or white space.") : DisplayName = displayName;

        public void SetEmail(Email email)
            => _= email == null ? throw new Exception("Email cannot be null") : Email = email;

        public void SetPassword(string password)
            => _= string.IsNullOrWhiteSpace(password) ? throw new Exception("Password cannot be null or white space.") : Password = password;
    }
}