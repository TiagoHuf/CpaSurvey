using Biopark.CpaSurvey.Domain.Exceptions;
using Biopark.CpaSurvey.Infra.CrossCutting.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Biopark.CpaSurvey.Infra.CrossCutting.Filters;

public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
{
    private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

    public ApiExceptionFilterAttribute()
    {
        _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
        {
            { typeof(ValidacaoException), HandleValidationException },
        };
    }

    public override void OnException(ExceptionContext context)
    {
        HandleException(context);
        base.OnException(context);
    }

    private void HandleException(ExceptionContext context)
    {
        var type = context.Exception.GetType();

        if (_exceptionHandlers.ContainsKey(type))
        {
            _exceptionHandlers[type].Invoke(context);
            return;
        }

        HandleUnknownException(context);
    }

    private static void HandleUnknownException(ExceptionContext context)
    {
        var result = new Response
        {
            Succeeded = false,
            Message = "Um erro interno ocorreu ao realizar a operação.",
        };

        context.Result = new ObjectResult(result)
        {
            StatusCode = StatusCodes.Status500InternalServerError,
        };

        context.ExceptionHandled = true;
    }

    private static void HandleValidationException(ExceptionContext context)
    {
        var exception = (ValidacaoException)context.Exception;

        var result = new Response
        {
            Succeeded = false,
            Message = "Falha ao validar os campos.",
            Errors = exception.Falhas,
        };

        context.Result = new BadRequestObjectResult(result);

        context.ExceptionHandled = true;
    }
}