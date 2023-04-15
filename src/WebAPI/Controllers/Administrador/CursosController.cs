using Biopark.CpaSurvey.Application.Cursos.Commands.CorrigirNome;
using Biopark.CpaSurvey.Application.Cursos.Commands.CriarCurso;
using Biopark.CpaSurvey.Application.Cursos.Commands.RemoverCurso;
using Biopark.CpaSurvey.Application.Cursos.Queries.GetCurso;
using Biopark.CpaSurvey.Application.Cursos.Queries.GetCursos;
using Biopark.CpaSurvey.Infra.CrossCutting.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Biopark.CpaSurvey.WebAPI.Controllers.Administrador;

public class CursosController : ApiController
{
    [HttpPost]
    [SwaggerOperation("Cadastra um novo curso.")]
    public async Task<IActionResult> PostCursoAsync([FromBody] CriarCursoCommand command)
    {
        var result = await Mediator.Send(command);
        return Created(
            "cursos/",
            new Response(result, "Curso cadastrado com sucesso.")
        );
    }

    [HttpGet]
    [SwaggerOperation("Retorna todos os cursos cadastrados.")]
    public async Task<IActionResult> GetCursosAsync([FromQuery] GetCursosQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("{cursoId:long}")]
    [SwaggerOperation("Retorna um curso através do identificador provido.")]
    public async Task<IActionResult> GetCursoAsync([FromRoute] GetCursoQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpPut("{cursoId:long}/corrigir-nome")]
    [SwaggerOperation("Corrige o nome de um curso através do identificador provido.")]
    public async Task<IActionResult> PutCorrigirNomeCursoAsync(
        [FromRoute] long cursoId, [FromBody] CorrigirNomeCursoCommand command)
    {
        if (cursoId != command.CursoId) return BadRequest();

        var result = await Mediator.Send(command);

        return Ok(new Response(result, "Nome do curso corrigido com sucesso."));
    }

    [HttpDelete("{cursoId:long}")]
    [SwaggerOperation("Remove um curso através do identificador provido.")]
    public async Task<IActionResult> DeleteCursoAsync([FromRoute] RemoverCursoCommand query)
    {
        var result = await Mediator.Send(query);

        return Ok(new Response(result, "Curso removido com sucesso."));
    }
}