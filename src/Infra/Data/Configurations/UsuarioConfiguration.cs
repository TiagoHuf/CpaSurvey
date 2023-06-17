using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore;
using Biopark.CpaSurvey.Domain.Entities.Usuarios;

namespace Biopark.CpaSurvey.Infra.Data.Configurations;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuario");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Login)
            .HasColumnName("Login")
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(p => p.Senha)
            .HasColumnName("Senha")
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(p => p.Role)
            .IsRequired()
            .HasConversion<EnumToNumberConverter<Role, long>>();
    }
}