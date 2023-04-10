using Biopark.CpaSurvey.Application.Disciplinas.Queries.GetDisciplinas;
using Biopark.CpaSurvey.Application.Disciplinas.Commands.CriarDisciplina;
using Biopark.CpaSurvey.Application.Disciplinas.Queries.GetDisciplina;
using Biopark.CpaSurvey.Infra.CrossCutting.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Biopark.CpaSurvey.Application.Disciplinas.Commands.RemoverDisciplina;

namespace Biopark.CpaSurvey.WebAPI.Controllers.Administrador;
public class DisciplinasController : ApiController
{
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] CriarDisciplinaCommand command)
    {
        var result = await Mediator.Send(command);
        return Created(
            "Disciplina/",
            new Response(result, "Disciplina cadastrado com sucesso.")
        );
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync([FromQuery] GetDisciplinasQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("{DisciplinaId:long}")]
    public async Task<IActionResult> GetAsync([FromRoute] GetDisciplinaQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpDelete("{DisciplinaId:long}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] RemoverDisciplinaCommand query)
    {
        var result = await Mediator.Send(query);

        return Ok(new Response(result, "Disciplina removida com sucesso."));
    }
}