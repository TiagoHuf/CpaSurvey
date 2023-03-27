
using Biopark.CpaSurvey.Application.Turmas.Commands.CriarTurma;
using Biopark.CpaSurvey.Application.Turmas.Queries.GetTurma;
using Biopark.CpaSurvey.Infra.CrossCutting.Wrappers;
using Microsoft.AspNetCore.Mvc;

namespace Biopark.CpaSurvey.WebAPI.Controllers.Administrador;

public class TurmaController : ApiController
{
    [HttpPost]

    public async Task<IActionResult> PostAsync([FromBody] CriarTurmaCommand command)
    {
        var result = await Mediator.Send(command);
        return Created("turma/", new Response(result, "Turma cadastrada com sucesso"));

    }

    [HttpGet]

    public async Task<IActionResult> GetAsync([FromQuery] GetTurmaQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("{TurmaId:long}")]

    public async Task<IActionResult> GetAsync([FromRoute] GetTurmaQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpDelete("{TurmaId:long}")]

    public async Task<IActionResult> DeleteAsync([FromRoute] GetTurmaQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result, "Turma removida com sucesso");
    }
}
