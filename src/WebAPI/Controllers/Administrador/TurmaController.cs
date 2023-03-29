using Biopark.CpaSurvey.Application.Turmas.Commands.CriarTurma;
using Biopark.CpaSurvey.Application.Turmas.Commands.RemoverTurma;
using Biopark.CpaSurvey.Application.Turmas.Queries.GetTurma;
using Biopark.CpaSurvey.Application.Turmas.Queries.GetTurmas;
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

    [HttpGet("{TurmaId:long}")]

    public async Task<IActionResult> GetAsync([FromRoute] GetTurmaQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync([FromQuery] GetTurmasQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpDelete("{TurmaId:long}")]

    public async Task<IActionResult> DeleteAsync([FromRoute] RemoverTurmaCommand query)
    {
        var result = await Mediator.Send(query);

        return Ok(new Response(result, "Turma removida com sucesso"));
    }
}