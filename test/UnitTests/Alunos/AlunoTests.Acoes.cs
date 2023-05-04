using Biopark.CpaSurvey.Domain.Entities.Alunos;
using FluentAssertions;
using NUnit.Framework;

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
}