using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using FluentValidation;

namespace Biopark.CpaSurvey.Application.Common.Validators;

public abstract class ValidatorBase<T> : AbstractValidator<T>
{
    protected ValidatorBase(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }

    protected IUnitOfWork UnitOfWork { get; }
}