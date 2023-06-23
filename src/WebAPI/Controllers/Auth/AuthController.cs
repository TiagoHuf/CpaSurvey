using Biopark.CpaSurvey.Application.Auth;
using Biopark.CpaSurvey.Infra.CrossCutting.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Biopark.CpaSurvey.WebAPI.Controllers.Auth;

public class AuthController : ApiController
{
    [HttpPost]
    [AllowAnonymous]
    [SwaggerOperation("Autenticação para obter um token valido para acesso.")]
    [ProducesResponseType(typeof(ResponseGeneric<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseGeneric<string>), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> PostLoginAsync(
        [FromBody] LoginCommand command)
    {
        var result = await Mediator.Send(command);
        if (result.IsAutenticado)
        {
            return Ok(new Response(result.Token, result.Mensagem));
        }

        return Unauthorized(new Response
        {
            Succeeded = false,
            Message = result.Mensagem,
        }
        );
    }
}