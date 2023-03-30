using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Biopark.CpaSurvey.Domain.Entities.Tipo;

namespace Biopark.CpaSurvey.Infra.Data.Configurations;
public class TipoConfiguration : IEntityTypeConfiguration<Tipo>
{
    public void Configure(EntityTypeBuilder<Tipo> builder)
    {
        builder.ToTable("Tipo");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Nome)
            .HasColumnName("Nome")
            .IsRequired()
            .HasMaxLength(50);
    }
}