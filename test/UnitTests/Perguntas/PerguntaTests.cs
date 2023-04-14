using Biopark.CpaSurvey.Domain.Entities.Perguntas;
using FluentAssertions;
using NUnit.Framework;

namespace Biopark.CpaSurvey.UnitTests.Perguntas;
public partial class PerguntaTests
{
    [Test]
    public void ConstrutorDeveCriarPerguntaComSucesso()
    {
        var model = PerguntaFactory.GetPerguntaNovaModel();

        var pergunta = new Pergunta(model);

        pergunta.Should().NotBeNull();
        pergunta.Descricao.Should().Be(model.Descricao);
        pergunta.EixoId.Should().Be(model.EixoId);
        pergunta.TipoResposta.Should().Be(model.TipoResposta);
    }
}