using Biopark.CpaSurvey.Domain.Entities.Alunos;
using FluentAssertions;
using NUnit.Framework;

namespace Biopark.CpaSurvey.UnitTests.Alunos;

public partial class AlunoTests : TestBase
{
    [Test]
    public void ConstrutorDeveCriarAlunoComSucesso()
    {
        var model = AlunoFactory.GetAlunoNovoModel();

        var aluno = new Aluno(model);

        aluno.Should().NotBeNull();
        aluno.Nome.Should().Be(model.Nome);
        aluno.Ra.Should().Be(model.Ra);
        aluno.IsAtivo.Should().BeTrue();
    }
}