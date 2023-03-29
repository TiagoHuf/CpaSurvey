using Biopark.CpaSurvey.Domain.Entities.Eixos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biopark.CpaSurvey.Infra.Data.Configurations;

public class EixoConfiguration : IEntityTypeConfiguration<Eixo>
{
    public void Configure(EntityTypeBuilder<Eixo> builder)
    {
        builder.ToTable("Eixo");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Nome)
            .HasColumnName("Nome")
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.Descricao)
            .HasColumnName("Descricao")
            .IsRequired()
            .HasMaxLength(200);
    }
}