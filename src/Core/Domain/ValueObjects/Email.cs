using System;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Core.Domain.ValueObjects
{
    public class Email
    {
        protected string Value {get;  set;}
        protected Email(){}
        protected Email(string value)
        {
            SetValue(value);
        }
        private void SetValue(string value)
        {
            value = value.ToLowerInvariant();

            if(string.IsNullOrWhiteSpace(value))
            {
                throw new Exception($"Email cannot be empty.");
            }
            else if(Value == value) return;

            MailAddress m = new MailAddress(value);
            
            Value = value;
        }

        public static Email Create(string value)
            => new Email(value);

        public override string ToString() => Value;
    }
}