using Biopark.CpaSurvey.Application.Tipo.Commands.RemoverTipoArea;
using Biopark.CpaSurvey.Application.TIpo.Commands.CriarTipo;
using Biopark.CpaSurvey.Application.TIpo.Commands.RemoverTipo;
using Biopark.CpaSurvey.Application.Tipos.Queries.GetTipo;
using Biopark.CpaSurvey.Application.Tipos.Queries.GetTipos;
using Biopark.CpaSurvey.Infra.CrossCutting.Wrappers;
using Microsoft.AspNetCore.Mvc;

namespace Biopark.CpaSurvey.WebAPI.Controllers.Administrador;
public class TipoController : ApiController
{
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] CriarTipoAreaCommand command)
    {
        var result = await Mediator.Send(command);
        return Created(
            "tipos/",
            new Response(result, "Tipo cadastrado com sucesso.")
        );
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync([FromQuery] GetTiposQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("{TipoId:long}")]
    public async Task<IActionResult> GetAsync([FromRoute] GetTipoAreaQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpDelete("{TipoId:long}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] RemoverTipoAreaCommand query)
    {
        var result = await Mediator.Send(query);

        return Ok(new Response(result, "Area removida com sucesso."));
    }
}