using Biopark.CpaSurvey.Application.Alunos.Commands.CriarAluno;
using Biopark.CpaSurvey.Application.Professores.Commands.CorrigirNome;
using Biopark.CpaSurvey.Application.Professores.Commands.RemoverProfessor;
using Biopark.CpaSurvey.Application.Professores.Queries.GetProfessor;
using Biopark.CpaSurvey.Infra.CrossCutting.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Biopark.CpaSurvey.WebAPI.Controllers.Administrador;

public class ProfessoresController : ApiController
{
    [HttpPost]
    [SwaggerOperation("Cadastra um novo professor.")]
    public async Task<IActionResult> PostCriarProfessorAsync([FromBody] CriarProfessorCommand command)
    {
        var result = await Mediator.Send(command);
        return Created(
            "professores/",
            new Response(result, "Professor cadastrado com sucesso.")
        );
    }

    [HttpGet]
    [SwaggerOperation("Retorna todos os professores cadastrados.")]
    public async Task<IActionResult> GetProfessoresAsync([FromQuery] GetProfessoresQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("{professorId:long}")]
    [SwaggerOperation("Retorna um professor através do identificador provido.")]
    public async Task<IActionResult> GetProfessorAsync([FromRoute] GetProfessorQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpPut("{professorId:long}/corrigir-nome")]
    [SwaggerOperation("Corrige o nome de um professor através do identificador provido.")]
    public async Task<IActionResult> PutCorrigirNomePProfessorAsync(
        [FromRoute] long professorId, [FromBody] CorrigirNomeProfessorCommand command)
    {
        if (professorId != command.ProfessorId) return BadRequest();

        var result = await Mediator.Send(command);

        return Ok(new Response(result, "Nome do professor corrigido com sucesso."));
    }

    [HttpDelete("{professorId:long}")]
    [SwaggerOperation("Remove um professor através do identificador provido.")]
    public async Task<IActionResult> DeleteProfessorAsync([FromRoute] RemoverProfessorCommand query)
    {
        var result = await Mediator.Send(query);

        return Ok(new Response(result, "Professor removido com sucesso."));
    }
}