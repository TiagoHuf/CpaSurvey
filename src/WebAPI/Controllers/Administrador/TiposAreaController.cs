using Biopark.CpaSurvey.Application.TiposArea.Commands.CorrigirNome;
using Biopark.CpaSurvey.Application.TiposArea.Commands.CriarTipoArea;
using Biopark.CpaSurvey.Application.TiposArea.Commands.RemoverTipoArea;
using Biopark.CpaSurvey.Application.TiposArea.Queries.GetTipo;
using Biopark.CpaSurvey.Application.TiposArea.Queries.GetTipos;
using Biopark.CpaSurvey.Infra.CrossCutting.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Biopark.CpaSurvey.WebAPI.Controllers.Administrador;

public class TiposAreaController : ApiController
{
    [HttpPost]
    [SwaggerOperation("Cadastra um novo tipo de área.")]
    public async Task<IActionResult> PostTipoAreaAsync([FromBody] CriarTipoAreaCommand command)
    {
        var result = await Mediator.Send(command);
        return Created(
            "tiposArea/",
            new Response(result, "Tipo de área cadastrado com sucesso.")
        );
    }

    [HttpGet]
    [SwaggerOperation("Retorna todos os tipos de área cadastrados.")]
    public async Task<IActionResult> GetTiposAreaAsync([FromQuery] GetTiposAreaQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("{tipoAreaId:long}")]
    [SwaggerOperation("Retorna um tipo de área através do identificador provido.")]
    public async Task<IActionResult> GetTipoAreaAsync([FromRoute] GetTipoAreaQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpPut("{tipoAreaId:long}/corrigir-nome")]
    [SwaggerOperation("Corrige o nome de um tipo de área através do identificador provido.")]
    public async Task<IActionResult> PutCorrigirNomeTipoAreaAsync(
        [FromRoute] long tipoAreaId, [FromBody] CorrigirNomeTipoAreaCommand command)
    {
        if (tipoAreaId != command.TipoAreaId) return BadRequest();

        var result = await Mediator.Send(command);

        return Ok(new Response(result, "Nome do tipo de área corrigido com sucesso."));
    }

    [HttpDelete("{tipoAreaId:long}")]
    [SwaggerOperation("Remove um tipo de área através do identificador provido.")]
    public async Task<IActionResult> DeleteTipoAreaAsync([FromRoute] RemoverTipoAreaCommand query)
    {
        var result = await Mediator.Send(query);

        return Ok(new Response(result, "Tipo de área removido com sucesso."));
    }
}