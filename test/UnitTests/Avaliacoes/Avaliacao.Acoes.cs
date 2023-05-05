using Biopark.CpaSurvey.Domain.Entities.Avaliacoes;
using Biopark.CpaSurvey.Domain.Entities.Cursos;
using Biopark.CpaSurvey.Domain.Entities.Turmas;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace Biopark.CpaSurvey.UnitTests.Avaliacoes;

public partial class AvaliacaoTest
{
    private Avaliacao _avaliacao;

    [SetUp]
    public void AvaliacaoTestsSetUp()
    {
        var model = AvaliacaoFactory.GetAvaliacaoNovaModel();
        _avaliacao = new Avaliacao(model);
    }

    [Test]
    public void DeveCorrigitNomeComSucesso()
    {
        var novoNome = "Novo Nome";

        _avaliacao.CorrigirNomeAvaliacao(novoNome);

        _avaliacao.Nome.Should().Be(novoNome);
    }

    [Test]
    public void DeveCorrigirDataInicioFimComSucesso()
    {
        var novaDataInicio = DateTime.Now;
        var novaDataFim =  DateTime.Now;

        _avaliacao.CorrigirDataAvaliacao(novaDataInicio, novaDataFim);

        _avaliacao.DataInicio.Should().Be(novaDataInicio);

        _avaliacao.DataFim.Should().Be(novaDataFim);
    }

    [Test]
    public void DeveRemoverCursoComSucesso(Curso curso)
    { 
        _avaliacao.RemoverCurso(curso);
    }

    [Test]
    public void DeveAdicionarCursoComSucesso(Curso curso)
    {
        _avaliacao.AdicionarCurso(curso);
    }

    [Test]
    public void DeveAdicionarTurmaComSucesso(Turma turma)
    {
        _avaliacao.AdicionarTurma(turma);
    }

    [Test]
    public void DeveRemoverTurmaComSucesso(Turma turma)
    {
        _avaliacao.RemoverTurma(turma);
    }

}