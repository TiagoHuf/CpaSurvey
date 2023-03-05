using Biopark.CpaSurvey.Domain.Entities.Eixos;
using Biopark.CpaSurvey.Domain.Entities.Perguntas;
using Biopark.CpaSurvey.Infra.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Biopark.CpaSurvey.Infra.Data.Context;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opcoes) : base(opcoes)
    {   

    }

    public ApplicationDbContext()
    {
    }

    public DbSet<Pergunta> Pergunta { get; set;}

    public DbSet<Eixo> Eixo { get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Pergunta>(new PerguntaConfiguration().Configure);
        modelBuilder.Entity<Eixo>(new EixoConfiguration().Configure);
    }

    public class YourDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=TenantTeste;Trusted_Connection=True;TrustServerCertificate=True");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}