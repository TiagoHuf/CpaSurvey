using Biopark.CpaSurvey.Domain.Entities.Respostas;
using FluentAssertions;
using NUnit.Framework;

namespace Biopark.CpaSurvey.UnitTests.Respostas;

public class RespostaTests : TestBase
{
    [Test]
    public void ConstrutorDeveCriarRespostaComSucesso()
    {
        var model = RespostaFactory.GetRespostaNovaModel();

        var reposta = new Resposta(model);

        reposta.Should().NotBeNull();
        reposta.Descricao.Should().Be(model.Descricao);
        reposta.Valor.Should().Be(model.Valor);
        reposta.PerguntaId.Should().Be(model.PerguntaId);
        reposta.AlunoId.Should().Be(model.AlunoId);
    }
}