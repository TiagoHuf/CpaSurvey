using Biopark.CpaSurvey.Domain.Entities.Respostas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biopark.CpaSurvey.Infra.Data.Configurations;

public class RespostaConfiguration : IEntityTypeConfiguration<Resposta>
{
    public void Configure(EntityTypeBuilder<Resposta> builder)
    {
        builder.ToTable("Resposta");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.Descricao)
            .HasColumnName("Descricao")
            .HasMaxLength(50);

        builder.Property(r => r.Valor);

        builder.HasIndex(r => r.AlunoId);

        builder.HasIndex(r => r.PerguntaId);

        builder.HasOne(r => r.Aluno)
            .WithMany(r => r.Respostas)
            .HasForeignKey(r => r.AlunoId)
            .HasConstraintName("FK_Aluno_Resposta_AlunoId");

        builder.HasOne(r => r.Pergunta)
            .WithMany(r => r.Respostas)
            .HasForeignKey(r => r.PerguntaId)
            .HasConstraintName("FK_Pergunta_Resposta_PerguntaId");
    }
}