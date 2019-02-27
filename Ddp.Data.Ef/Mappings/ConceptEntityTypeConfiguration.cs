using Ddp.Data.Ef.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ddp.Data.Ef.Mappings
{
    public class ConceptEntityTypeConfiguration : IEntityTypeConfiguration<ConceptTable>
    {
        public void Configure(EntityTypeBuilder<ConceptTable> builder)
        {
            builder.HasKey(x => x.ConceptId);
            builder.HasMany<ConceptAttributeTable>().WithOne().HasForeignKey(x => x.ConceptId).HasPrincipalKey(x=>x.ConceptId);
            builder.Property(x => x.Name);
            builder.Property(x => x.Description);
        }
    }
}