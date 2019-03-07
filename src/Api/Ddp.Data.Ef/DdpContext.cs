using Ddp.Data.Ef.Tables;
using Microsoft.EntityFrameworkCore;

namespace Ddp.Data.Ef
{
    public class DdpContext : DbContext
    {
        public DdpContext(DbContextOptions<DdpContext> options) : base(options)
        {

        }
        public DbSet<EventTable> EventTables { get; set; }
        public DbSet<EntityTypeTable> EntityTypeTables { get; set; }
        public DbSet<ConceptTable> ConceptTables { get; set; }
        public DbSet<ConceptAttributeTable> ConceptAttributeTables { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DdpContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}