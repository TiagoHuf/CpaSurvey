using Biopark.CpaSurvey.Application.Common.Validators;
using Biopark.CpaSurvey.Domain.Entities.Eixos;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using FluentValidation;

namespace Biopark.CpaSurvey.Application.Eixos.Commands.CorrigirDescricao;

public class CorrigirDescricaoEixoCommandValidator : ValidatorBase<CorrigirDescricaoEixoCommand>
{
    public CorrigirDescricaoEixoCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.Descricao)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(200);

        RuleFor(p => p.EixoId)
            .MustExists<CorrigirDescricaoEixoCommand, Eixo>(unitOfWork);
    }
}