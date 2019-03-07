using Ddp.Data.Ef.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ddp.Data.Ef.Mappings
{
    public class EntityTypeTimePropertyTableEntityTypeConfiguration : IEntityTypeConfiguration<EntityTypeTimePropertyTable>
    {
        public void Configure(EntityTypeBuilder<EntityTypeTimePropertyTable> builder)
        {
            builder.HasKey(x => x.EntityTypeTimePropertyId);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.MinimumValue);
            builder.Property(x => x.MaximumValue);
            builder.Property(x => x.IsRequired).IsRequired();
            builder.Property(x => x.MaximumAllowed);

            builder.HasOne<EntityTypeTable>().WithMany().HasForeignKey(x => x.EntityTypeId);
        }
    }
}
