using System;

namespace Core.Domain.Entities
{
    public class EmailSettings
    {
        public Guid Id {get; protected set;}
        public string Host {get; protected set;}
        public int Port {get; protected set;}
        public string Username {get; protected set;}
        public string Password {get; protected set;} 

        public EmailSettings(Guid id, string host, int port, string username, string password)
        {
            Id = id;
            Host = host;
            Port = port;
            Username = username;
            Password = password;
        }

        
    }
}