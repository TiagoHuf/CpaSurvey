﻿using Biopark.CpaSurvey.Domain.Entities.Turmas;

namespace Biopark.CpaSurvey.Domain.Models.Avaliacoes;

public class AvaliacaoModel
{
    public string Nome { get; set; }

    public DateTime DataInicio { get; set; }

    public DateTime DataFim { get; set; }

    //public List<Curso> Cursos { get; set; }

    public List<Turma> Turmas { get; set; }
}