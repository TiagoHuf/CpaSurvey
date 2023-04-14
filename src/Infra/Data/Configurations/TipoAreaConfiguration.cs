using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Biopark.CpaSurvey.Domain.Entities.TipoArea;

namespace Biopark.CpaSurvey.Infra.Data.Configurations;
public class TipoAreaConfiguration : IEntityTypeConfiguration<TipoArea>
{
    public void Configure(EntityTypeBuilder<TipoArea> builder)
    {
        builder.ToTable("Tipo");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Nome)
            .HasColumnName("Nome")
            .IsRequired()
            .HasMaxLength(50);
    }
}