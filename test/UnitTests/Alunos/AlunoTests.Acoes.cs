using Biopark.CpaSurvey.Domain.Entities;
using Biopark.CpaSurvey.Domain.Entities.Alunos;
using Biopark.CpaSurvey.Domain.Entities.Disciplinas;
using Biopark.CpaSurvey.Domain.Entities.Turmas;
using Biopark.CpaSurvey.UnitTests.Disciplinas;
using Biopark.CpaSurvey.UnitTests.Turmas;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;

namespace Biopark.CpaSurvey.UnitTests.Alunos;

public partial class AlunoTests
{
    private Aluno _aluno;

    [SetUp]
    public void AlunoTestsSetUp()
    {
        var model = AlunoFactory.GetAlunoNovoModel();
        _aluno = new Aluno(model);
    }

    [Test]
    public void DeveCorrigirNomeComSucesso()
    {
        var novoNome = "Novo Nome";

        _aluno.CorrigirNome(novoNome);

        _aluno.Nome.Should().Be(novoNome);
    }

    [Test]
    public void DeveCorrigirRaComSucesso()
    {
        var novoRa = "Novo Ra";

        _aluno.CorrigirRa(novoRa);

        _aluno.Ra.Should().Be(novoRa);
    }

    [Test]
    public void DeveAtivarAlunoComSucesso()
    {
        _aluno.Inativar();

        _aluno.Ativar();

        _aluno.IsAtivo.Should().BeTrue();
    }

    [Test]
    public void DeveInativarAlunoComSucesso()
    {
        _aluno.Ativar();

        _aluno.Inativar();

        _aluno.IsAtivo.Should().BeFalse();
    }

    [Test]
    public void DeveAdicionarDisciplina() 
    {
        Disciplina disciplina = DisciplinaFactory.GetDisciplinaNova("Nova Disciplina");

        var count = _aluno.Disciplinas.Count + 1;

        _aluno.AdicionarDisciplina(disciplina);

        _aluno.Disciplinas.Should().HaveCount(count);
    }

    [Test]
    public void DeveAdicionarTurma()
    {
        Turma turma = TurmaFactory.GetTurmaNova("Nova Turma");

        _aluno.AdicionarTurma(turma);

        _aluno.Turmas.First().Should().Be(turma);
    }

}