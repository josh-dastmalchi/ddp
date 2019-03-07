using Ddp.Data.Ef.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ddp.Data.Ef.Mappings
{
    public class ConceptAttributeEntityTypeConfiguration : IEntityTypeConfiguration<ConceptAttributeTable>
    {
        public void Configure(EntityTypeBuilder<ConceptAttributeTable> builder)
        {
            builder.HasKey(x => x.ConceptAttributeId);
            builder.Property(x => x.Name);

            builder.HasOne<ConceptTable>().WithMany().HasForeignKey(x => x.ConceptId).HasPrincipalKey(x => x.ConceptId);
        }
    }
}