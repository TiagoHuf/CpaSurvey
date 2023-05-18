using Biopark.CpaSurvey.Domain.Entities.Alunos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biopark.CpaSurvey.Infra.Data.Configurations;

public class AlunoConfiguration : IEntityTypeConfiguration<Aluno>
{
    public void Configure(EntityTypeBuilder<Aluno> builder)
    {
        builder.ToTable("Aluno");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id);

        builder.Property(a => a.Nome)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(a => a.Ra)
            .IsRequired()
            .HasMaxLength(8);

        builder.Property(a => a.IsAtivo)
            .IsRequired();

        builder.HasMany(a => a.Turmas)
            .WithMany(t => t.Alunos);

        builder.HasOne(a => a.Curso)
            .WithMany(c => c.Alunos)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasForeignKey(p => p.CursoId)
            .HasConstraintName("FK_Curso_Aluno_CursoId");
    }
}