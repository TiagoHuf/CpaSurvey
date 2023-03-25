using Biopark.CpaSurvey.Domain.Entities.Cursos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biopark.CpaSurvey.Infra.Data.Configurations
{
    public class CursosConfiguration : IEntityTypeConfiguration<Cursos>
    {
        public void Configure(EntityTypeBuilder<Cursos> builder)
        {
            builder.ToTable("Cursos");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nome)
                .HasColumnName("Nome")
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
   