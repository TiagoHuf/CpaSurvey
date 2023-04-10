using Biopark.CpaSurvey.Application.Eixoas.Queries.GetEixos;
using Biopark.CpaSurvey.Application.Eixos.Commands.CriarEixo;
using Biopark.CpaSurvey.Application.Eixos.Commands.RemoverEixo;
using Biopark.CpaSurvey.Application.Eixos.Queries.GetEixo;
using Biopark.CpaSurvey.Infra.CrossCutting.Wrappers;
using Microsoft.AspNetCore.Mvc;

namespace Biopark.CpaSurvey.WebAPI.Controllers.Administrador;

public class EixosController : ApiController
{
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] CriarEixoCommand command)
    {
        var result = await Mediator.Send(command);
        return Created(
            "eixos/",
            new Response(result, "Eixo cadastrado com sucesso.")
        );
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync([FromQuery] GetEixosQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("{EixoId:long}")]
    public async Task<IActionResult> GetAsync([FromRoute] GetEixoQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpDelete("{EixoId:long}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] RemoverEixoCommand query)
    {
        var result = await Mediator.Send(query);

        return Ok(new Response(result, "Eixo removida com sucesso."));
    }
}