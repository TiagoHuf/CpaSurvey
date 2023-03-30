using Biopark.CpaSurvey.Application.TIpo.Commands.CriarTipo;
using Biopark.CpaSurvey.Application.Tipos.Queries.GetTipo;
using Biopark.CpaSurvey.Application.Tipos.Queries.GetTipos;
using Biopark.CpaSurvey.Infra.CrossCutting.Wrappers;
using Microsoft.AspNetCore.Mvc;

namespace Biopark.CpaSurvey.WebAPI.Controllers.Administrador;
public class TipoController : ApiController
{
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] CriarTipoCommand command)
    {
        var result = await Mediator.Send(command);
        return Created(
            "tipos/",
            new Response(result, "Eixo cadastrado com sucesso.")
        );
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync([FromQuery] GetTiposQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("{TipoId:long}")]
    public async Task<IActionResult> GetAsync([FromRoute] GetTipoQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }
}