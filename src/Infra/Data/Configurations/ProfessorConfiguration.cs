using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Biopark.CpaSurvey.Domain.Entities.Professores;

namespace Biopark.CpaSurvey.Infra.Data.Configurations;

public class ProfessorConfiguration : IEntityTypeConfiguration<Professor>
{
    public void Configure(EntityTypeBuilder<Professor> builder)
    {
        builder.ToTable("Professor");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Nome)
            .HasColumnName("Nome")
            .IsRequired()
            .HasMaxLength(50);
    }
}