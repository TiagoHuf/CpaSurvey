using Biopark.CpaSurvey.Application.Common.Validators;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using FluentValidation;

namespace Biopark.CpaSurvey.Application.TIpo.Commands.CriarTipo;
public class CriarTipoValidator : ValidatorBase<CriarTipoCommand>
{
    public CriarTipoValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.Nome)
            .NotEmpty()
            .MinimumLength(5)
            .MaximumLength(200);
    }
}