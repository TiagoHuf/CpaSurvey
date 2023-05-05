using Biopark.CpaSurvey.Domain.Entities.Cursos;
using Biopark.CpaSurvey.Domain.Entities.Turmas;
using Biopark.CpaSurvey.Domain.Models.Avaliacoes;
using Biopark.CpaSurvey.UnitTests.Cursos;
using Biopark.CpaSurvey.UnitTests.Turmas;
using System;
using System.Collections.Generic;

namespace Biopark.CpaSurvey.UnitTests.Avaliacoes;

public class AvaliacaoFactory
{
    public static AvaliacaoModel GetAvaliacaoNovaModel()
    {
        var cursos = new List<Curso>
        {
            CursoFactory.GetCursoNovo("Curso 1"),
            CursoFactory.GetCursoNovo("Curso 2"),
            CursoFactory.GetCursoNovo("Curso 3"),
        };

        var turmas = new List<Turma>
        {
            TurmaFactory.GetTurmaNova("Turma 1"),
            TurmaFactory.GetTurmaNova("Turma 2"),
            TurmaFactory.GetTurmaNova("Turma 3"),
        };

        return new AvaliacaoModel
        {
            Nome = "Avaliação teste",
            DataInicio = DateTime.Now,
            DataFim = DateTime.Now,
            Cursos = cursos,
            Turmas = turmas,
        };
    }
}