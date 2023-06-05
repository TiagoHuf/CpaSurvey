using Biopark.CpaSurvey.Domain.Entities.Eixos;
using FluentAssertions;
using NUnit.Framework;

namespace Biopark.CpaSurvey.UnitTests.Eixos;

public partial class EixoTests
{
    private Eixo _eixo;

    [SetUp]
    public void EixoTestsSetUp()
    {
        var model = EixoFactory.GetEixoNovoModel();
        _eixo = new Eixo(model);
    }

    [Test]
    public void CorrigirNomeComSucesso()
    {
        var novoNome = "Novo Nome";

        _eixo.CorrigirNome(novoNome);

        _eixo.Nome.Should().Be(novoNome);
    }

    [Test]
    public void CorrigirDescricaoComSucesso()
    {
        var novaDescricao = "Nova Descrição";

        _eixo.CorrigirDescricao(novaDescricao);

        _eixo.Descricao.Should().Be(novaDescricao);
    }
}
