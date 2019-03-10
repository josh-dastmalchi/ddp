using Autofac;
using Ddp.Data.Ef.Repositories;
using Ddp.Domain.ConceptualModel.Repositories;
using Ddp.Domain.Domains.Repositories;
using Ddp.Domain.EntityRelationshipModel.Repositories;

namespace Ddp.Data.Ef.Autofac
{
    public class DdpDataEfAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DdpContextProvider>().As<IDdpContextProvider>().InstancePerLifetimeScope(); ;
            builder.RegisterType<SqlServerEventStore>().As<IEventStore>();
            builder.RegisterType<ConceptRepository>().As<IConceptRepository>();
            builder.RegisterType<DomainRepository>().As<IDomainRepository>();
            builder.RegisterType<EntityTypeRepository>().As<IEntityTypeRepository>();
        }
    }
}