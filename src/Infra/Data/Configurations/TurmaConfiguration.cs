using Biopark.CpaSurvey.Domain.Entities.Turmas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biopark.CpaSurvey.Infra.Data.Configurations;

public class TurmaConfiguration : IEntityTypeConfiguration<Turma>
{
    public void Configure(EntityTypeBuilder<Turma> builder)
    {
        builder.ToTable("turma");

        builder.HasKey(e => e.Id);

        builder.Property(p => p.Nome)
            .HasColumnName("nome")
            .IsRequired()
            .HasMaxLength(200);

        builder.HasIndex(p => p.CursoId);

        //builder.Property(p => p.Curso)
        //    .WithMany(e => e.Turma)
        //    .HasForeignKey(p => p.CursoId)
        //    .HasConstraintName("FK_Turma_Curso_CursoId");
    }
}