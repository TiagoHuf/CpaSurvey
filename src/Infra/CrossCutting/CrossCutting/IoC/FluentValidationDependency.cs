using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Biopark.CpaSurvey.Infra.CrossCutting.IoC;

public static class FluentValidationDependency
{
    public static void AddFluentValidationDependency(this IServiceCollection services, Assembly assembly)
    {
#pragma warning disable CS0618 // O tipo ou membro é obsoleto
        ValidatorOptions.Global.CascadeMode = CascadeMode.StopOnFirstFailure;
#pragma warning restore CS0618 // O tipo ou membro é obsoleto
        services.AddValidatorsFromAssembly(assembly);
    }
}