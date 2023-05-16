using Biopark.CpaSurvey.Domain.Entities.Perguntas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Biopark.CpaSurvey.Infra.Data.Configurations;

public class PerguntaConfiguration : IEntityTypeConfiguration<Pergunta>
{
    public void Configure(EntityTypeBuilder<Pergunta> builder)
    {
        builder.ToTable("Pergunta");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Descricao)
            .HasColumnName("Descricao")
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(p => p.TipoResposta)
            .IsRequired()
            .HasConversion<EnumToNumberConverter<TipoResposta, long>>();

        builder.HasIndex(p => p.EixoId);

        builder.HasOne(p => p.Eixo)
            .WithMany(p => p.Perguntas)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasForeignKey(p => p.EixoId)
            .HasConstraintName("FK_Eixo_Pergunta_EixoId");

        builder.HasMany(a => a.Avaliacoes)
            .WithMany(p => p.Perguntas);
    }
}