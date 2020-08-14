using Autofac;
using Infrastructure.Mapper;

namespace Infrastructure.IoC.Modules
{
    public class MapperModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(AutoMapperConfig.Initialize())
                .SingleInstance();
        }
    }
}