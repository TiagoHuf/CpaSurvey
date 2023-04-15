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

        builder.HasIndex(p => p.CursoId);

        builder.HasOne(p => p.Curso)
            .WithMany(p => p.Avaliacoes)
            .HasForeignKey(p => p.CursoId)
            .HasConstraintName("FK_Curso_Avaliacao_CursoId");

        builder.HasIndex(p => p.TurmaId);

        builder.HasOne(p => p.Turma)
            .WithMany(p => p.Avaliacoes)
            .HasForeignKey(p => p.TurmaId)
            .HasConstraintName("FK_Turma_Avaliacao_TurmaId");
    }
}