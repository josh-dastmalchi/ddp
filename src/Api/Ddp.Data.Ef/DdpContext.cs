using Ddp.Data.Ef.Tables;
using Microsoft.EntityFrameworkCore;

namespace Ddp.Data.Ef
{
    public class DdpContext : DbContext
    {
        public DdpContext(DbContextOptions<DdpContext> options) : base(options)
        {

        }
        public DbSet<ConceptTable> ConceptTables { get; set; }
        public DbSet<ConceptAttributeTable> ConceptAttributeTables { get; set; }
        public DbSet<DomainTable> DomainTables { get; set; }
        public DbSet<EventTable> EventTables { get; set; }
        public DbSet<EntityTypeTable> EntityTypeTables { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DdpContext).Assembly);

            // Ignore these until we use them
            modelBuilder.Ignore<EntityTypeDatePropertyTable>();
            modelBuilder.Ignore<EntityTypeDateTimePropertyTable>();
            modelBuilder.Ignore<EntityTypeTable>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
