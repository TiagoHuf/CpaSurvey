using Biopark.CpaSurvey.Domain.Common;

namespace Biopark.CpaSurvey.Infra.CrossCutting.Wrappers;

public abstract class ResponseGeneric<T>
{
    public T Data { get; set; }

    public bool Succeeded { get; set; }

    public IReadOnlyCollection<ValidacaoFalha> Errors { get; set; }

    public string Message { get; set; }
}