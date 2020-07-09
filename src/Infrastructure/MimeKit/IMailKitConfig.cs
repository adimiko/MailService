namespace Infrastructure.MimeKit
{
    public interface IMailKitConfig
    {
        string Smtp {get;}
        int Port {get;}
        string Username {get;}
        string Password {get;}
    }
}