using Biopark.CpaSurvey.Application.Common.Validators;
using Biopark.CpaSurvey.Domain.Entities.Cursos;
using Biopark.CpaSurvey.Domain.Entities.Turmas;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using FluentValidation;

namespace Biopark.CpaSurvey.Application.Avaliacoes.Commands.CriarAvalicao;

public class CriarAvaliacaoCommandValidator : ValidatorBase<CriarAvaliacaoCommand>
{
    public CriarAvaliacaoCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.Nome)
            .NotEmpty()
            .MinimumLength(2)
            .MinimumLength(50);

        //Descobrir como fazer para pegar a data do pc e não poder colocar uma data anterior a essa
        RuleFor(p => p.DataInicio)
            .NotEmpty();
    
        RuleFor(p => p.DataFim)
            .NotEmpty();

        RuleFor(p => p.CursoId)
            .MustExists<CriarAvaliacaoCommand, Curso>(unitOfWork);

        RuleFor(p => p.TurmaId)
            .MustExists<CriarAvaliacaoCommand, Turma>(unitOfWork);
    }
}