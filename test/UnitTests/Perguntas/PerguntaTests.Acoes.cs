using Biopark.CpaSurvey.Domain.Entities.Perguntas;
using FluentAssertions;
using NUnit.Framework;

namespace Biopark.CpaSurvey.UnitTests.Perguntas
{
    public partial class PerguntaTests
    {
        private Pergunta _pergunta;

        [SetUp]
        public void PerguntaTestsSetUp()
        {
            var model = PerguntaFactory.GetPerguntaNovaModel();
            _pergunta = new Pergunta(model);
        }

        [Test]
        public void DeveCorrigirDescricaoComSucesso()
        {
            var NovaDescricao = "Nova descrição";

            _pergunta.CorrigirDescricao(NovaDescricao);

            _pergunta.Descricao.Should().Be(NovaDescricao);
        }

        [Test]
        public void DeveCorrigirEixoComSucesso()
        {
            var NovoEixo = 0;

            _pergunta.CorrigirEixo(NovoEixo);

            _pergunta.EixoId.Should().Be(NovoEixo);
        }

        [Test]
        public void DeveCorrigirTipoRespostaComSucesso()
        {
            var NovoTipoResposta = TipoResposta.EscalaLikert;

            _pergunta.CorrigirTipoResposta(NovoTipoResposta);

            _pergunta.TipoResposta.Should().Be(NovoTipoResposta);
        }
    }
}
