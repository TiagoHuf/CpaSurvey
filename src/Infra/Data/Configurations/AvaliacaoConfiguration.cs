using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Biopark.CpaSurvey.Domain.Entities.Avaliacoes;

namespace Biopark.CpaSurvey.Infra.Data.Configurations;

public class AvaliacaoConfiguration : IEntityTypeConfiguration<Avaliacao>
{
    public void Configure(EntityTypeBuilder<Avaliacao> builder)
    {
        builder.ToTable("Avaliacao");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id);

        builder.Property(a => a.Nome)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(a => a.DataInicio)
            .IsRequired();

        builder.Property(a => a.DataFim) 
            .IsRequired();

        builder.Property(a => a.Cursos)
            .IsRequired();

        builder.Property(a => a.Turmas)
            .IsRequired();
    }
}