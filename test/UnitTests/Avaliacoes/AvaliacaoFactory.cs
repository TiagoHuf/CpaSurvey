using Biopark.CpaSurvey.Domain.Models.Avaliacoes;
using System;

namespace Biopark.CpaSurvey.UnitTests.Avaliacoes;

public class AvaliacaoFactory
{
    public static AvaliacaoModel GetAvaliacaoNovaModel()
    {
<<<<<<< HEAD
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

=======
>>>>>>> 3c8892b096853c518fd255e3381310fff743e11a
        return new AvaliacaoModel
        {
            Nome = "Avaliação teste",
            DataInicio = DateTime.Now,
            DataFim = DateTime.Now,
            DisciplinaId = 1,
        };
    }
}