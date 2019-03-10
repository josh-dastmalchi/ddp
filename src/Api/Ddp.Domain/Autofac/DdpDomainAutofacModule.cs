using Autofac;

namespace Ddp.Domain.Autofac
{
    public class DdpDomainAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DomainEventDispatcher>().As<IDomainEventDispatcher>().InstancePerLifetimeScope();
        }
    }
}