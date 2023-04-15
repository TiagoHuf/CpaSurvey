using Biopark.CpaSurvey.Application.Disciplinas.Queries.GetDisciplinas;
using Biopark.CpaSurvey.Application.Disciplinas.Commands.CriarDisciplina;
using Biopark.CpaSurvey.Application.Disciplinas.Queries.GetDisciplina;
using Biopark.CpaSurvey.Infra.CrossCutting.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Biopark.CpaSurvey.Application.Disciplinas.Commands.RemoverDisciplina;
using Biopark.CpaSurvey.Application.Disciplinas.Commands.CorrigirNome;
using Swashbuckle.AspNetCore.Annotations;

namespace Biopark.CpaSurvey.WebAPI.Controllers.Administrador;

public class DisciplinasController : ApiController
{
    [HttpPost]
    [SwaggerOperation("Cadastra uma nova disciplina.")]
    public async Task<IActionResult> PostDisciplinaAsync([FromBody] CriarDisciplinaCommand command)
    {
        var result = await Mediator.Send(command);
        return Created(
            "disciplinas/",
            new Response(result, "Disciplina cadastrada com sucesso.")
        );
    }

    [HttpGet]
    [SwaggerOperation("Retorna todas as disciplinas cadastradas.")]
    public async Task<IActionResult> GetDisciplinasAsync([FromQuery] GetDisciplinasQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("{disciplinaId:long}")]
    [SwaggerOperation("Retorna uma disciplina através do identificador provido.")]
    public async Task<IActionResult> GetDisciplinaAsync([FromRoute] GetDisciplinaQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpPut("{disciplinaId:long}/corrigir-nome")]
    [SwaggerOperation("Corrige o nome de uma disciplina através do identificador provido.")]
    public async Task<IActionResult> PutCorrigirNomeDisciplinaAsync(
        [FromRoute] long disciplinaId, [FromBody] CorrigirNomeDisciplinaCommand command)
    {
        if (disciplinaId != command.DisciplinaId) return BadRequest();

        var result = await Mediator.Send(command);

        return Ok(new Response(result, "Nome da disciplina corrigido com sucesso."));
    }

    [HttpDelete("{disciplinaId:long}")]
    [SwaggerOperation("Remove uma disciplina através do identificador provido.")]
    public async Task<IActionResult> DeleteDisciplinaAsync([FromRoute] RemoverDisciplinaCommand query)
    {
        var result = await Mediator.Send(query);

        return Ok(new Response(result, "Disciplina removida com sucesso."));
    }
}