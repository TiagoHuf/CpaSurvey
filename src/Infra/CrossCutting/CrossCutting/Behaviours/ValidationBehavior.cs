using Biopark.CpaSurvey.Domain.Common;
using Biopark.CpaSurvey.Domain.Exceptions;
using FluentValidation;
using MediatR;

namespace Biopark.CpaSurvey.Infra.CrossCutting.Behaviours;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        CancellationToken cancellationToken,
        RequestHandlerDelegate<TResponse> next)
    {
        // Caso não tenha nenhum validator, continua
        if (!_validators.Any()) return await next();

        // Context para execução das validações
        var context = new ValidationContext<TRequest>(request);

        // Gera as tarefas
        var failures = _validators
            .Select(v => v.ValidateAsync(context, cancellationToken));

        // Aguarda as validações assíncronas
        var validationResults = await Task.WhenAll(failures);

        // Pega as falhas do Fluent
        var falhasFluent = validationResults.SelectMany(f => f.Errors).Where(e => e != null);

        // Converte para o modelo de falha
        var fails = falhasFluent
            .Select(f => new ValidacaoFalha(f.PropertyName, f.ErrorMessage))
            .ToList();

        // Se não houver falhas, conrinua
        if (fails.Count is 0) return await next();
      
        var msg = Environment.NewLine +
            string.Join(
                Environment.NewLine,
                fails.Select(f => f.PropertyName + " - " + f.ErrorMessage)
            );

        throw new ValidacaoException(fails, msg);
    }
}