using Biopark.CpaSurvey.Domain.Entities.Usuarios;
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
            .HasMaxLength(200);

        builder.Property(a => a.IsAtivo)
            .IsRequired();
    }
}