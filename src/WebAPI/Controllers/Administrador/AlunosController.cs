using Biopark.CpaSurvey.Application.Alunos.Commands.AdicionarDisciplina;
using Biopark.CpaSurvey.Application.Alunos.Commands.AdicionarTurma;
using Biopark.CpaSurvey.Application.Alunos.Commands.Ativar;
using Biopark.CpaSurvey.Application.Alunos.Commands.CorrigirNome;
using Biopark.CpaSurvey.Application.Alunos.Commands.CorrigirRa;
using Biopark.CpaSurvey.Application.Alunos.Commands.CriarAluno;
using Biopark.CpaSurvey.Application.Alunos.Commands.Inativar;
using Biopark.CpaSurvey.Application.Alunos.Commands.RemoverAluno;
using Biopark.CpaSurvey.Application.Alunos.Queries.GetAluno;
using Biopark.CpaSurvey.Application.Alunos.Queries.GetAlunos;
using Biopark.CpaSurvey.Infra.CrossCutting.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Biopark.CpaSurvey.WebAPI.Controllers.Administrador;

public class AlunosController : ApiController
{
    [HttpPost]
    [SwaggerOperation("Cadastra um novo aluno.")]
    public async Task<IActionResult> PostCriarAlunoAsync([FromBody] CriarAlunoCommand command)
    {
        var result = await Mediator.Send(command);
        return Created(
            "alunos/",
            new Response(result, "Aluno cadastrado com sucesso.")
        );
    }

    [HttpGet]
    [SwaggerOperation("Retorna todos os alunos cadastrados.")]
    public async Task<IActionResult> GetAlunosAsync([FromQuery] GetAlunosQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("{alunoId:long}")]
    [SwaggerOperation("Retorna um aluno através do identificador provido.")]
    public async Task<IActionResult> GetGetAlunoAsync([FromRoute] GetAlunoQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpPut("{alunoId:long}/corrigir-nome")]
    [SwaggerOperation("Corrige o nome de um aluno através do identificador provido.")]
    public async Task<IActionResult> PutCorrigirNomeAlunoAsync(
        [FromRoute] long alunoId, [FromBody] CorrigirNomeAlunoCommand command)
    {
        if (alunoId != command.AlunoId) return BadRequest();

        var result = await Mediator.Send(command);

        return Ok(new Response(result, "Nome do aluno corrigido com sucesso."));
    }

    [HttpPut("{alunoId:long}/corrigir-ra")]
    [SwaggerOperation("Corrige o RA de um aluno através do identificador provido.")]
    public async Task<IActionResult> PutCorrigirRaAlunoAsync(
        [FromRoute] long alunoId, [FromBody] CorrigirRaAlunoCommand command)
    {
        if (alunoId != command.AlunoId) return BadRequest();

        var result = await Mediator.Send(command);

        return Ok(new Response(result, "RA do aluno corrigido com sucesso."));
    }

    [HttpPut("{alunoId:long}/ativar")]
    [SwaggerOperation("Ativa um aluno através do identificador provido.")]
    public async Task<IActionResult> PutAtivarAlunoAsync([FromRoute] AtivarAlunoCommand command)
    {
        var result = await Mediator.Send(command);

        return Ok(new Response(result, "Aluno ativado com sucesso."));
    }

    [HttpPut("{alunoId:long}/inativar")]
    [SwaggerOperation("Inativa um aluno através do identificador provido.")]
    public async Task<IActionResult> PutInativarAlunoAsync([FromRoute] InativarAlunoCommand command)
    {
        var result = await Mediator.Send(command);

        return Ok(new Response(result, "Aluno inativado com sucesso."));
    }

    [HttpDelete("{alunoId:long}")]
    [SwaggerOperation("Remove um aluno através do identificador provido.")]
    public async Task<IActionResult> DeleteAlunoAsync([FromRoute] RemoverAlunoCommand command)
    {
        var result = await Mediator.Send(command);

        return Ok(new Response(result, "Aluno removido com sucesso."));
    }

    [HttpPut("{alunoId:long}/adicionar-disciplina")]
    [SwaggerOperation("Adiciona uma disciplina ao aluno através dos identificadores providos.")]
    public async Task<IActionResult> PutAdicionarDisciplinaAlunoAsync(
        [FromRoute] long alunoId, [FromBody] AdicionarDisciplinaAlunoCommand command)
    {
        if (alunoId != command.AlunoId) return BadRequest();

        var result = await Mediator.Send(command);

        return Ok(new Response(result, "Disciplina adicionada com sucesso."));
    }

    [HttpPut("{alunoId:long}/adicionar-turma")]
    [SwaggerOperation("Adiciona uma turma ao aluno através dos identificadores providos.")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> PutAdicionarTurmaAlunoAsync(
        [FromRoute] long alunoId, [FromBody] AdicionarTurmaAlunoCommand command)
    {
        if (alunoId != command.AlunoId) return BadRequest();

        var result = await Mediator.Send(command);

        return Ok(new Response(result, "Turma adicionada com sucesso."));
    }
}
