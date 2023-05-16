using Biopark.CpaSurvey.Application.Common.Validators;
using Biopark.CpaSurvey.Domain.Entities.Professores;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;

namespace Biopark.CpaSurvey.Application.Professores.Commands.RemoverProfessor;

public class RemoverProfessorCommandValidator : ValidatorBase<RemoverProfessorCommand>
{
    public RemoverProfessorCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.ProfessorId)
            .MustExists<RemoverProfessorCommand, Professor>(unitOfWork);
    }
}