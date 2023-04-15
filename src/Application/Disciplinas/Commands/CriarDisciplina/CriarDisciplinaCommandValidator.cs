using Biopark.CpaSurvey.Application.Common.Validators;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using FluentValidation;

namespace Biopark.CpaSurvey.Application.Disciplinas.Commands.CriarDisciplina;

public class CriarDisciplinaCommandValidator : ValidatorBase<CriarDisciplinaCommand>
{
    public CriarDisciplinaCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.Descricao)
            .NotEmpty()
            .MinimumLength(2)
            .MinimumLength(50);
    }
}