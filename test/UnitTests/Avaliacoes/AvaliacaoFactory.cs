using Biopark.CpaSurvey.Domain.Entities.Turmas;
using Biopark.CpaSurvey.Domain.Models.Avaliacoes;
using Biopark.CpaSurvey.UnitTests.Turmas;
using System;
using System.Collections.Generic;

namespace Biopark.CpaSurvey.UnitTests.Avaliacoes;

public class AvaliacaoFactory
{
    public static AvaliacaoModel GetAvaliacaoNovaModel()
    {
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
            DisciplinaId = 1,
        };
    }
}