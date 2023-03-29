using Biopark.CpaSurvey.Domain.Entities.Cursos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biopark.CpaSurvey.Infra.Data.Configurations;

public class CursoConfiguration : IEntityTypeConfiguration<Curso>
{
    public void Configure(EntityTypeBuilder<Curso> builder)
    {
        builder.ToTable("Curso");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Nome)
            .HasColumnName("Nome")
            .IsRequired()
            .HasMaxLength(50);
    }
}