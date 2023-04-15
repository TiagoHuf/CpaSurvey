using Biopark.CpaSurvey.Application.Eixoas.Queries.GetEixos;
using Biopark.CpaSurvey.Application.Eixos.Commands.CorrigirDescricao;
using Biopark.CpaSurvey.Application.Eixos.Commands.CorrigirNome;
using Biopark.CpaSurvey.Application.Eixos.Commands.CriarEixo;
using Biopark.CpaSurvey.Application.Eixos.Commands.RemoverEixo;
using Biopark.CpaSurvey.Application.Eixos.Queries.GetEixo;
using Biopark.CpaSurvey.Infra.CrossCutting.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Biopark.CpaSurvey.WebAPI.Controllers.Administrador;

public class EixosController : ApiController
{
    [HttpPost]
    [SwaggerOperation("Cadastra um novo eixo.")]
    public async Task<IActionResult> PostEixoAsync([FromBody] CriarEixoCommand command)
    {
        var result = await Mediator.Send(command);
        return Created(
            "eixos/",
            new Response(result, "Eixo cadastrado com sucesso.")
        );
    }

    [HttpGet]
    [SwaggerOperation("Retorna todos os eixos cadastrados.")]
    public async Task<IActionResult> GetEixosAsync([FromQuery] GetEixosQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("{eixoId:long}")]
    [SwaggerOperation("Retorna um eixo através do identificador provido.")]
    public async Task<IActionResult> GetEixoAsync([FromRoute] GetEixoQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpPut("{eixoId:long}/corrigir-nome")]
    [SwaggerOperation("Corrige o nome de um eixo através do identificador provido.")]
    public async Task<IActionResult> PutCorrigirNomeEixoAsync(
        [FromRoute] long eixoId, [FromBody] CorrigirNomeEixoCommand command)
    {
        if (eixoId != command.EixoId) return BadRequest();

        var result = await Mediator.Send(command);

        return Ok(new Response(result, "Nome do eixo corrigido com sucesso."));
    }

    [HttpPut("{eixoId:long}/corrigir-descricao")]
    [SwaggerOperation("Corrige a descrição de um eixo através do identificador provido.")]
    public async Task<IActionResult> PutCorrigirDescricaoEixoAsync(
        [FromRoute] long eixoId, [FromBody] CorrigirDescricaoEixoCommand command)
    {
        if (eixoId != command.EixoId) return BadRequest();

        var result = await Mediator.Send(command);

        return Ok(new Response(result, "Descrição do eixo corrigida com sucesso."));
    }

    [HttpDelete("{eixoId:long}")]
    [SwaggerOperation("Remove um eixo através do identificador provido.")]
    public async Task<IActionResult> DeleteEixoAsync([FromRoute] RemoverEixoCommand query)
    {
        var result = await Mediator.Send(query);

        return Ok(new Response(result, "Eixo removido com sucesso."));
    }
}