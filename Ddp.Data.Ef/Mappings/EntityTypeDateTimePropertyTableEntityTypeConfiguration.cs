using Ddp.Data.Ef.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ddp.Data.Ef.Mappings
{
    public class EntityTypeDateTimePropertyTableEntityTypeConfiguration : IEntityTypeConfiguration<EntityTypeDateTimePropertyTable>
    {
        public void Configure(EntityTypeBuilder<EntityTypeDateTimePropertyTable> builder)
        {
            builder.HasKey(x => x.EntityTypeDateTimePropertyId);
            builder.Property(x => x.DateTimeProperty).IsRequired();
            builder.Property(x => x.MaximumAllowed);

            builder.HasOne<EntityTypeTable>().WithMany().HasForeignKey(x => x.EntityTypeId);
        }
    }
}
