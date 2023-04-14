using Biopark.CpaSurvey.Domain.Entities.Disciplinas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Infra.Data.Configurations;

public class DisciplinaConfiguration : IEntityTypeConfiguration<Disciplina>
{
    public void Configure(EntityTypeBuilder<Disciplina> builder)
    {
        builder.ToTable("Disciplina");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Nome)
            .HasColumnName("Nome")
            .IsRequired()
            .HasMaxLength(50);
    }
}