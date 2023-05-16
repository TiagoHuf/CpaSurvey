namespace Biopark.CpaSurvey.Domain.Common;

[Serializable]
public class ValidacaoFalha
{
    public ValidacaoFalha(string property, string message)
    {
        PropertyName = property;
        ErrorMessage = message;
    }

    public string PropertyName { get; }

    public string ErrorMessage { get; }

    public override string ToString()
    {
        return PropertyName + " : " + ErrorMessage;
    }
}