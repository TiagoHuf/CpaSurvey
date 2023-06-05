using Biopark.CpaSurvey.Domain.Entities.Disciplinas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Infra.Data.Configurations;

public class DisciplinaConfiguration : IEntityTypeConfiguration<Disciplina>
{
    public void Configure(EntityTypeBuilder<Disciplina> builder)
    {
        builder.ToTable("Disciplina");

        builder.HasKey(d => d.Id);

        builder.Property(d => d.Nome)
            .HasColumnName("Nome")
            .IsRequired()
            .HasMaxLength(50);

        builder.HasOne(d => d.Curso)
            .WithMany(c => c.Disciplinas)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasForeignKey(r => r.CursoId)
            .HasConstraintName("FK_Curso_Disciplina_DisciplinaId");

        builder.HasOne(d => d.Professor)
            .WithMany(c => c.Disciplinas)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasForeignKey(r => r.ProfessorId)
            .HasConstraintName("FK_Professor_Disciplina_ProfessorId");
    }
}