using Biopark.CpaSurvey.Application.Common.Validators;
using Biopark.CpaSurvey.Domain.Entities.Disciplinas;
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
            .MaximumLength(50);

        RuleFor(p => p.DataInicio)
            .NotEmpty()
            .GreaterThan(DateTime.Now);

        RuleFor(p => p.DataFim)
            .NotEmpty()
            .GreaterThan(p => p.DataInicio);

        RuleFor(p => p.DisciplinaId)
            .MustExists<CriarAvaliacaoCommand, Disciplina>(unitOfWork);
    }
}