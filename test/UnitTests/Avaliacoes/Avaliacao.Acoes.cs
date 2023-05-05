using Biopark.CpaSurvey.Domain.Entities.Avaliacoes;
using Biopark.CpaSurvey.Domain.Entities.Cursos;
using Biopark.CpaSurvey.Domain.Entities.Turmas;
using Biopark.CpaSurvey.Domain.Models.Avaliacoes;
using Biopark.CpaSurvey.UnitTests.Cursos;
using Biopark.CpaSurvey.UnitTests.Turmas;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;

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
    public void DeveRemoverCursoComSucesso()
    { 
        Curso curso = CursoFactory.GetCursoNovo("Curso 3");

        var count = _avaliacao.Cursos.Count - 1;

        _avaliacao.RemoverCurso(curso);

        _avaliacao.Cursos.Should().HaveCountGreaterThan(count);
    }

    [Test]
    public void DeveAdicionarCursoComSucesso()
    {
        Curso curso = CursoFactory.GetCursoNovo("Cruso 4");

        var count = _avaliacao.Cursos.Count + 1;

        _avaliacao.AdicionarCurso(curso);

        _avaliacao.Cursos.Should().HaveCount(count);
    }

    [Test]
    public void DeveAdicionarTurmaComSucesso()
    {
        Turma turma = TurmaFactory.GetTurmaNova("Turma 4");

        var count = _avaliacao.Turmas.Count + 1;

        _avaliacao.AdicionarTurma(turma);

        _avaliacao.Turmas.Should().HaveCount(count);
    }

    [Test]
    public void DeveRemoverTurmaComSucesso()
    {
        Turma turma = TurmaFactory.GetTurmaNova("Turma 3");

        var count = _avaliacao.Turmas.Count - 1;
        
        _avaliacao.RemoverTurma(turma);

        _avaliacao.Turmas.Should().HaveCountGreaterThan(count);
    }
}