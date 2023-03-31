using Biopark.CpaSurvey.Application.Common.Validators;
using Biopark.CpaSurvey.Application.TIpo.Commands.CriarTipo;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using FluentValidation;

namespace Biopark.CpaSurvey.Application.Tipo.Commands.CriarTipo;

public class CriarTipoAreaValidator : ValidatorBase<CriarTipoAreaCommand>
{
    public CriarTipoAreaValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.Nome)
            .NotEmpty()
            .MinimumLength(5)
            .MaximumLength(200);
    }
}