using Biopark.CpaSurvey.Domain.Entities.Turma;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;


namespace Biopark.CpaSurvey.Infra.Data.Configurations;

public class TurmaConfiguration : IEntityTypeConfiguration<Turma>
{
    public object Configure(EntityTypeBuilder<Turma> builder)
    {
        builder.ToTable("turma");

        builder.HasKey(e => e.Id);

        builder.Property(p => p.Nome)
            .HasColumnName("nome")
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(p => p.Dt_inicio)
            .HasColumnName("dt_inicio")
            .IsRequired();

        builder.Property(p => p.Dt_finale)
            .HasColumnName("dt_final")
            .IsRequired();

        builder.HasIndex(p => p.CursoId);

        builder.Property(p => p.Curso)
            .WithMany(e => e.Turma)
            .HasForeignKey(p => p.CursoId)
            .HasConstraintName("FK_Turma_Curso_CursoId");
    }
}
