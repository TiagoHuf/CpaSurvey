using Biopark.CpaSurvey.Domain.Entities.Cursos;
using Biopark.CpaSurvey.Domain.Entities.Disciplinas;
using Biopark.CpaSurvey.Domain.Entities.Eixos;
using Biopark.CpaSurvey.Domain.Entities.Perguntas;
using Biopark.CpaSurvey.Domain.Entities.Respostas;
using Biopark.CpaSurvey.Domain.Entities.Turmas;
using Biopark.CpaSurvey.Domain.Entities.Alunos;
using Biopark.CpaSurvey.Infra.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Biopark.CpaSurvey.Domain.Entities.Avaliacoes;
using Biopark.CpaSurvey.Domain.Entities;
using Biopark.CpaSurvey.Domain.Entities.Professores;
using Biopark.CpaSurvey.Domain.Entities.Usuarios;

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

        modelBuilder.Entity<Usuario>(new UsuarioConfiguration().Configure);
        modelBuilder.Entity<Aluno>(new AlunoConfiguration().Configure);
        modelBuilder.Entity<AlunoDisciplina>(new AlunoDisciplinaConfiguration().Configure);
        modelBuilder.Entity<Avaliacao>(new AvaliacaoConfiguration().Configure);
        modelBuilder.Entity<Curso>(new CursoConfiguration().Configure);
        modelBuilder.Entity<Disciplina>(new DisciplinaConfiguration().Configure);
        modelBuilder.Entity<Eixo>(new EixoConfiguration().Configure);
        modelBuilder.Entity<Pergunta>(new PerguntaConfiguration().Configure);
        modelBuilder.Entity<Professor>(new ProfessorConfiguration().Configure);
        modelBuilder.Entity<Resposta>(new RespostaConfiguration().Configure);
        modelBuilder.Entity<Turma>(new TurmaConfiguration().Configure);
    }

    public class YourDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseMySql("Server=us-cdbr-east-06.cleardb.net;Database=heroku_16cc917e02fee03;User Id=bc300c9d2cbb35;Password=2596311e;", serverVersion);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}