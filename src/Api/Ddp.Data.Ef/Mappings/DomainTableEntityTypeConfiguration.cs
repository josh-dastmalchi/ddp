using Ddp.Data.Ef.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ddp.Data.Ef.Mappings
{
    public class DomainTableEntityTypeConfiguration : IEntityTypeConfiguration<DomainTable>
    {
        public void Configure(EntityTypeBuilder<DomainTable> builder)
        {
            builder.ToTable("Domains");
            builder.HasKey(x => x.DomainId);
            builder.Property(x => x.Name).IsRequired();
        }
    }
}
