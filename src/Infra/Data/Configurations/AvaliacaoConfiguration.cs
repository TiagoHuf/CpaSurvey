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

        builder.Property(a => a.Nome)
            .HasColumnName("Nome")
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(a => a.DataInicio);

        builder.Property(a => a.DataFim);

        builder.HasIndex(a => a.DisciplinaId);

        builder.HasOne(a => a.Disciplina)
            .WithMany(d => d.Avaliacoes)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasForeignKey(r => r.DisciplinaId)
            .HasConstraintName("FK_Disciplina_Avaliacao_DisciplinaId");

        builder.HasMany(a => a.Perguntas)
            .WithMany(p => p.Avaliacoes);
    }
}