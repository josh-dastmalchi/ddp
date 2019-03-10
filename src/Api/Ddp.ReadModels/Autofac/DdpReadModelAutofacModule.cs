using Autofac;

namespace Ddp.ReadModels.Autofac
{
    public class DdpReadModelAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(GetType().Assembly)
                .AsClosedTypesOf(typeof(IQueryHandler<,>))
                .AsImplementedInterfaces();
        }
    }
}