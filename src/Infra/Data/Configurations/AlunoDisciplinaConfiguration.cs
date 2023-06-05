using Biopark.CpaSurvey.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biopark.CpaSurvey.Infra.Data.Configurations;

public class AlunoDisciplinaConfiguration : IEntityTypeConfiguration<AlunoDisciplina>
{
    public void Configure(EntityTypeBuilder<AlunoDisciplina> builder)
    {
        builder.ToTable("AlunoDisciplina");

        builder.HasKey(a => a.Id);

        builder.HasOne(a => a.Disciplina)
            .WithMany(d => d.Alunos)
            .HasForeignKey(r => r.DisciplinaId)
            .HasConstraintName("FK_AlunoDisciplina_Disciplina_DisciplinaId");

        builder.HasOne(a => a.Aluno)
            .WithMany(a => a.Disciplinas)
            .HasForeignKey(a => a.AlunoId)
            .HasConstraintName("FK_AlunoDisciplina_Aluno_AlunoId");
    }
}