using Biopark.CpaSurvey.Domain.Entities.Turmas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biopark.CpaSurvey.Infra.Data.Configurations;

public class TurmaConfiguration : IEntityTypeConfiguration<Turma>
{
    public void Configure(EntityTypeBuilder<Turma> builder)
    {
        builder.ToTable("Turma");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Nome)
            .HasColumnName("nome")
            .IsRequired()
            .HasMaxLength(50);

        builder.HasIndex(t => t.CursoId);

        builder.HasOne(t => t.Curso)
            .WithMany(t => t.Turmas)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasForeignKey(t => t.CursoId)
            .HasConstraintName("FK_Curso_Turma_CursoId");

        builder.HasMany(a => a.Alunos)
            .WithMany(t => t.Turmas);
    }
}