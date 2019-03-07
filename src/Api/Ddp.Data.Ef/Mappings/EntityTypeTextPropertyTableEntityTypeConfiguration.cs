using Ddp.Data.Ef.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ddp.Data.Ef.Mappings
{
    public class EntityTypeTextPropertyTableEntityTypeConfiguration : IEntityTypeConfiguration<EntityTypeTextPropertyTable>
    {
        public void Configure(EntityTypeBuilder<EntityTypeTextPropertyTable> builder)
        {
            builder.HasKey(x => x.EntityTypeTextPropertyId);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.MinimumLength);
            builder.Property(x => x.MaximumLength);
            builder.Property(x => x.IsRequired).IsRequired();
            builder.Property(x => x.MaximumAllowed);

            builder.HasOne<EntityTypeTable>().WithMany().HasForeignKey(x => x.EntityTypeId);
        }
    }
}
