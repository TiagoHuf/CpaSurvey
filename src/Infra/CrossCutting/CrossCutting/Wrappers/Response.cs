namespace Biopark.CpaSurvey.Infra.CrossCutting.Wrappers;

public class Response : ResponseGeneric<object>
{
    public Response()
    {
    }

    public Response(object data)
    {
        Succeeded = true;
        Message = string.Empty;
        Errors = null;
        Data = data;
    }

    public Response(object data, string message)
    {
        Succeeded = true;
        Message = message;
        Errors = null;
        Data = data;
    }
}