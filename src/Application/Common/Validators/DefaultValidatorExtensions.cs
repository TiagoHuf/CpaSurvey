using Biopark.CpaSurvey.Domain.Entities;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using FluentValidation;

namespace Biopark.CpaSurvey.Application.Common.Validators;

public static class DefaultValidatorExtensions
{
    public static IRuleBuilderOptions<T, long> MustExists<T, TEntity>(this IRuleBuilder<T, long> ruleBuilder, IUnitOfWork unitOfWork) where TEntity : BaseEntity<long>
    {
        return ruleBuilder.MustExists<T, TEntity, long>(unitOfWork);
    }

    public static IRuleBuilderOptions<T, TKey> MustExists<T, TEntity, TKey>(this IRuleBuilder<T, TKey> ruleBuilder, IUnitOfWork unitOfWork) where TEntity : BaseEntity<TKey>
    {
        if (unitOfWork == null)
        {
            throw new ArgumentNullException(nameof(unitOfWork));
        }

        return ruleBuilder.SetAsyncValidator(new ExistirRegistroValidator<T, TEntity, TKey>(unitOfWork));
    }
}