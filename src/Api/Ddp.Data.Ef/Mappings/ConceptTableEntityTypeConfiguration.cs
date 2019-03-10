using Ddp.Data.Ef.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ddp.Data.Ef.Mappings
{
    public class ConceptTableEntityTypeConfiguration : IEntityTypeConfiguration<ConceptTable>
    {
        public void Configure(EntityTypeBuilder<ConceptTable> builder)
        {
            builder.ToTable("Concepts");
            builder.HasKey(x => x.ConceptId);
            builder.HasMany<ConceptAttributeTable>().WithOne().HasForeignKey(x => x.ConceptId).HasPrincipalKey(x=>x.ConceptId);
            builder.HasOne<DomainTable>().WithMany().HasForeignKey(x=>x.DomainId).HasPrincipalKey(x=>x.DomainId);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description);
        }
    }
}
