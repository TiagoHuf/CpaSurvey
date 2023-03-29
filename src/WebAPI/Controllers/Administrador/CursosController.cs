using Biopark.CpaSurvey.Application.Cursos.Commands.CriarCurso;
using Biopark.CpaSurvey.Application.Cursos.Commands.Queries.GetCurso;
using Biopark.CpaSurvey.Application.Cursos.Commands.Queries.GetCursos;
using Biopark.CpaSurvey.Infra.CrossCutting.Wrappers;
using Microsoft.AspNetCore.Mvc;

namespace Biopark.CpaSurvey.WebAPI.Controllers.Administrador;

public class CursosController : ApiController
{
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] CriarCursoCommand command)
    {
        var result = await Mediator.Send(command);
        return Created(
            "Cursos/",
            new Response(result, "Curso cadastrado com sucesso.")
        );
    }

    [HttpGet("{CursoId:long}")]
    public async Task<IActionResult> GetAsync([FromRoute] GetCursoQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync([FromQuery] GetCursosQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }
}