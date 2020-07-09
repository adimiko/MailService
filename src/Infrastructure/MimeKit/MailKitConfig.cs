namespace Infrastructure.MimeKit
{
    public class MailKitConfig : IMailKitConfig
    {
        public string Smtp {get; protected set;}
        public int Port {get; protected set;}
        public string Username {get; protected set;}
        public string Password {get; protected set;}
    }
}