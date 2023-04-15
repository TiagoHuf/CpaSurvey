using Biopark.CpaSurvey.Application.Common.Validators;
using Biopark.CpaSurvey.Domain.Entities.TiposArea;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using FluentValidation;

namespace Biopark.CpaSurvey.Application.TiposArea.Commands.CorrigirNome;

public class CorrigirNomeTipoAreaCommandValidator : ValidatorBase<CorrigirNomeTipoAreaCommand>
{
    public CorrigirNomeTipoAreaCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.Nome)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50);

        RuleFor(p => p.TipoAreaId)
            .MustExists<CorrigirNomeTipoAreaCommand, TipoArea>(unitOfWork);
    }
}