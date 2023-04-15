using Biopark.CpaSurvey.Application.Disciplinas.Commands.RemoverDisciplina;
using Biopark.CpaSurvey.Application.TiposArea.Commands.CriarTipoArea;
using Biopark.CpaSurvey.Application.TiposArea.Commands.RemoverTipoArea;
using Biopark.CpaSurvey.Application.TiposArea.Queries.GetTipo;
using Biopark.CpaSurvey.Application.TiposArea.Queries.GetTipos;
using Biopark.CpaSurvey.Infra.CrossCutting.Wrappers;
using Microsoft.AspNetCore.Mvc;

namespace Biopark.CpaSurvey.WebAPI.Controllers.Administrador;

public class TiposAreaController : ApiController
{
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] CriarTipoAreaCommand command)
    {
        var result = await Mediator.Send(command);
        return Created(
            "tipo-area/",
            new Response(result, "Tipo de área cadastrado com sucesso.")
        );
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync([FromQuery] GetTiposAreaQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("{TipoAreaId:long}")]
    public async Task<IActionResult> GetAsync([FromRoute] GetTipoAreaQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpDelete("{TipoAreaId:long}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] RemoverTipoAreaCommand query)
    {
        var result = await Mediator.Send(query);

        return Ok(new Response(result, "Tipo de área removido com sucesso."));
    }
}