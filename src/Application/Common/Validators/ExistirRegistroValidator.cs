using Biopark.CpaSurvey.Domain.Entities;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using FluentValidation.Validators;
using FluentValidation;

namespace Biopark.CpaSurvey.Application.Common.Validators;
public class ExistirRegistroValidator<T, TEntity, TKey>
        : AsyncPropertyValidator<T, TKey> where TEntity : BaseEntity<TKey>
{
    private readonly IUnitOfWork _unitOfWork;

    private string _message;

    public ExistirRegistroValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _message = "Registro não encontrado.";
    }

    public override string Name => "ExistirRegistroValidator";

    public override async Task<bool> IsValidAsync(
        ValidationContext<T> context,
        TKey value,
        CancellationToken cancellation)
    {
        switch (value)
        {
            case long and <= 0:
            case int and <= 0:
                _message = "Identificador inválido.";
                return false;
        }

        var repository = _unitOfWork.GetRepository<TEntity>();

        return await repository.ExistsAsync(m => m.Id.Equals(value), cancellation);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) => _message;
}