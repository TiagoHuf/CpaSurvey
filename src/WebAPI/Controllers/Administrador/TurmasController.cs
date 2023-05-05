using Biopark.CpaSurvey.Application.Turmas.Commands.CorrigirNome;
using Biopark.CpaSurvey.Application.Turmas.Commands.CriarTurma;
using Biopark.CpaSurvey.Application.Turmas.Commands.RemoverTurma;
using Biopark.CpaSurvey.Application.Turmas.Queries.GetTurma;
using Biopark.CpaSurvey.Application.Turmas.Queries.GetTurmas;
using Biopark.CpaSurvey.Infra.CrossCutting.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Biopark.CpaSurvey.WebAPI.Controllers.Administrador;

public class TurmasController : ApiController
{
    [HttpPost]
    [SwaggerOperation("Cadastra uma nova turma.")]
    public async Task<IActionResult> PostTurmaAsync([FromBody] CriarTurmaCommand command)
    {
        var result = await Mediator.Send(command);
        return Created(
            "turmas/",
            new Response(result, "Turma cadastrada com sucesso"));

    }

    [HttpGet]
    [SwaggerOperation("Retorna todas as turmas cadastradas.")]
    public async Task<IActionResult> GetTurmasAsync([FromQuery] GetTurmasQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("{turmaId:long}")]
    [SwaggerOperation("Retorna uma turma através do identificador provido.")]
    public async Task<IActionResult> GetTurmaAsync([FromRoute] GetTurmaQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpPut("{turmaId:long}/corrigir-nome")]
    [SwaggerOperation("Corrige o nome de uma turma através do identificador provido.")]
    public async Task<IActionResult> PutCorrigirNomeTurmaAsync(
        [FromRoute] long turmaId, [FromBody] CorrigirNomeTurmaCommand command)
    {
        if (turmaId != command.TurmaId) return BadRequest();

        var result = await Mediator.Send(command);

        return Ok(new Response(result, "Nome da turma corrigido com sucesso."));
    }

    [HttpDelete("{turmaId:long}")]
    [SwaggerOperation("Remove uma turma através do identificador provido.")]
    public async Task<IActionResult> DeleteTurmaAsync([FromRoute] RemoverTurmaCommand query)
    {
        var result = await Mediator.Send(query);

        return Ok(new Response(result, "Turma removida com sucesso"));
    }
}