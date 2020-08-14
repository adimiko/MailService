using System;
using System.Reflection;
using Application.Services.Implementations;
using Application.Services.Interfaces;
using Autofac;
using Infrastructure.Services;

namespace Infrastructure.IoC.Modules
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MailService>().As<IMailService>();
            builder.RegisterType<EmailSettingsService>().As<IEmailSettingsService>();
            builder.RegisterType<MailKitProvider>().As<IMailKitProvider>();
            builder.RegisterType<AesEncrypterProvider>().As<IEncrypterProvider>();
        }
    }
}