using Ddp.Data.Ef.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ddp.Data.Ef.Mappings
{
    // What an unfortunate naming collision
    public class EntityTypeTableEntityTypeConfiguration : IEntityTypeConfiguration<EntityTypeTable>
    {
        public void Configure(EntityTypeBuilder<EntityTypeTable> builder)
        {
            builder.HasKey(x => x.EntityTypeId);
        }
    }
}
