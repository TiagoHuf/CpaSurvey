using Biopark.CpaSurvey.Domain.Common;
using System.Runtime.Serialization;

namespace Biopark.CpaSurvey.Domain.Exceptions;

[Serializable]
[KnownType(typeof(List<ValidacaoFalha>))]
public class ValidacaoException : Exception
{
    public ValidacaoException() : base("Uma ou mais falhas de validação ocorreram.")
    {
        Falhas = new List<ValidacaoFalha>();
    }

    public ValidacaoException(ValidacaoFalha falha) : this()
    {
        Falhas.Add(falha);
    }

    protected ValidacaoException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
        Falhas = (List<ValidacaoFalha>)info.GetValue(nameof(Falhas), typeof(List<ValidacaoFalha>));
    }

    public List<ValidacaoFalha> Falhas { get; }

    public ValidacaoException(IEnumerable<ValidacaoFalha> falhas, string message) : base(message)
    {
        Falhas = falhas.ToList();
    }

#if DEBUG
    public override string Message => string.Join(Environment.NewLine, Falhas);
#endif

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue(nameof(Falhas), Falhas, typeof(List<ValidacaoFalha>));
        base.GetObjectData(info, context);
    }

    public override string ToString()
    {
        return Message + 
            Environment.NewLine +
            string.Join(Environment.NewLine, Falhas);
    }
}