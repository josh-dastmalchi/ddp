using Ddp.Data.Ef.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ddp.Data.Ef.Mappings
{
    public class EventTableEntityTypeConfiguration : IEntityTypeConfiguration<EventTable>
    {
        public void Configure(EntityTypeBuilder<EventTable> builder)
        {
            builder.HasKey(x => x.EventId);
            builder.Property(x => x.EntityId).IsRequired();
            builder.Property(x => x.EntityType).IsRequired().HasMaxLength(450);
            builder.Property(x => x.EventData);
            builder.Property(x => x.EventType).IsRequired().HasMaxLength(450);
            builder.Property(x => x.Version);
            builder.Ignore(x => x.Sequence);
        }
    }
}