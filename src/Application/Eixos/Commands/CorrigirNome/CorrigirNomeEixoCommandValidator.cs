using Biopark.CpaSurvey.Application.Common.Validators;
using Biopark.CpaSurvey.Domain.Entities.Eixos;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using FluentValidation;

namespace Biopark.CpaSurvey.Application.Eixos.Commands.CorrigirNome;

public class CorrigirNomeEixoCommandValidator : ValidatorBase<CorrigirNomeEixoCommand>
{
    public CorrigirNomeEixoCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.Nome)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50);

        RuleFor(p => p.EixoId)
            .MustExists<CorrigirNomeEixoCommand, Eixo>(unitOfWork);
    }
}