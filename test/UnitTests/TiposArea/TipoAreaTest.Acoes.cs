using Biopark.CpaSurvey.Domain.Entities.TiposArea;
using FluentAssertions;
using NUnit.Framework;

namespace Biopark.CpaSurvey.UnitTests.TiposArea
{
    public partial class TipoAreaTests
    {

        private TipoArea _tipoarea;

        [SetUp]
        public void TipoAreaTestsSetUp()
        {
            var model = TipoAreaFactory.GetTipoAreaNovaModel();
            _tipoarea = new TipoArea(model);
        }

        [Test]
        public void DeveCorrigirNomeComSucesso()
        {
            var NovoNome = "Novo Nome";

            _tipoarea.CorrigirNome(NovoNome);

            _tipoarea.Nome.Should().Be(NovoNome);
        }
    }
}
