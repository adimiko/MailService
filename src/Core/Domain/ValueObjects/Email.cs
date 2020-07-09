using System;
using System.Text.RegularExpressions;

namespace Core.Domain.ValueObjects
{
    public class Email
    {
        public string Value {get; protected set;}
        protected Email(){}
        protected Email(string value)
        {
            SetValue(value);
        }
        private void SetValue(string value)
        {
            value = value.ToLowerInvariant();

            Regex regEmail;
            regEmail = new Regex(@"^[a-z][a-z0-9_]*@[a-z0-9]*\.[a-z]{2,3}$");
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new Exception($"Email cannot be empty.");
            }
            else if(!regEmail.IsMatch(value))
            {
                throw new Exception($"Wrong email format.");
            }
            else if(Value == value) return;

            Value = value;
        }

        public static Email Create(string value)
            => new Email(value);
    }
}