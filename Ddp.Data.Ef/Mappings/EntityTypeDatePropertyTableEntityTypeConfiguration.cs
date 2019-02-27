using Ddp.Data.Ef.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ddp.Data.Ef.Mappings
{
    public class EntityTypeDatePropertyTableEntityTypeConfiguration : IEntityTypeConfiguration<EntityTypeDatePropertyTable>
    {
        public void Configure(EntityTypeBuilder<EntityTypeDatePropertyTable> builder)
        {
            builder.HasKey(x => x.EntityTypeDatePropertyId);
            builder.Property(x => x.DateTimeProperty).IsRequired();
            builder.Property(x => x.MaximumAllowed);

            builder.HasOne<EntityTypeTable>().WithMany().HasForeignKey(x => x.EntityTypeId);
        }
    }
}
