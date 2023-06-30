using Biopark.CpaSurvey.Application.Alunos.Queries.GetAluno;
using Biopark.CpaSurvey.Application.Alunos.Queries.GetAlunos;
using Biopark.CpaSurvey.Application.Avaliacoes.Commands.AdicionarPergunta;
using Biopark.CpaSurvey.Application.Avaliacoes.Commands.AdicionarTurma;
using Biopark.CpaSurvey.Application.Avaliacoes.Commands.CriarAvalicao;
using Biopark.CpaSurvey.Application.Avaliacoes.Commands.RemoverPergunta;
using Biopark.CpaSurvey.Application.Avaliacoes.Commands.RemoverTurma;
using Biopark.CpaSurvey.Application.Avaliacoes.Queries.GetAvaliacao;
using Biopark.CpaSurvey.Application.Avaliacoes.Queries.GetAvaliacoes;
using Biopark.CpaSurvey.Infra.CrossCutting.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Biopark.CpaSurvey.WebAPI.Controllers.Administrador;

public class AvaliacaoController : ApiController
{
    [HttpPost]
    [SwaggerOperation("Cria uma nova avaliação.")]
    public async Task<IActionResult> PostAvaliacaoAsync([FromBody] CriarAvaliacaoCommand command)
    {
        var result = await Mediator.Send(command);
        return Created(
            "avaliacoes/",
            new Response(result, "Avaliação criada com sucesso.")
        );
    }

    [HttpGet]
    [SwaggerOperation("Retorna todas as avaliações cadastradas.")]
    public async Task<IActionResult> GetAvaliacoesAsync([FromQuery] GetAvaliacoesQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("{avaliacaoId:long}")]
    [SwaggerOperation("Retorna uma avaliação através do identificador provido.")]
    public async Task<IActionResult> GetAvaliacaoAsync([FromRoute] GetAvaliacaoQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpPut("{avaliacaoId:long}/adicionar-pergunta")]
    [SwaggerOperation("Adiciona uma pergunta à avaliação através dos identificadores providos.")]
    public async Task<IActionResult> PutAdicionarPerguntaAsync(
        [FromRoute] long avaliacaoId, [FromBody] AdicionarPerguntaCommand command)
    {
        if (avaliacaoId != command.AvaliacaoId) return BadRequest();

        var result = await Mediator.Send(command);

        return Ok(new Response(result, "Pergunta adicionada à avaliação com sucesso."));
    }

    [HttpPut("{avaliacaoId:long}/remover-pergunta")]
    [SwaggerOperation("Remove uma pergunta de uma avaliação através dos identificadores providos.")]
    public async Task<IActionResult> PutRemoverPerguntaAsync(
        [FromRoute] long avaliacaoId, [FromBody] RemoverPerguntaCommand command)
    {
        if (avaliacaoId != command.AvaliacaoId) return BadRequest();

        var result = await Mediator.Send(command);

        return Ok(new Response(result, "Pergunta removida da avaliação com sucesso."));
    }

    [HttpPut("{avaliacaoId:long}/adicionar-turma")]
    [SwaggerOperation("Adiciona uma turma à avaliação através dos identificadores providos.")]
    public async Task<IActionResult> PutAdicionarTurmaAsync(
        [FromRoute] long avaliacaoId, [FromBody] AdicionarTurmaCommand command)
    {
        if (avaliacaoId != command.AvaliacaoId) return BadRequest();

        var result = await Mediator.Send(command);

        return Ok(new Response(result, "Turma adicionada à avaliação com sucesso."));
    }

    [HttpPut("{avaliacaoId:long}/remover-turma")]
    [SwaggerOperation("Remove uma turma de uma avaliação através dos identificadores providos.")]
    public async Task<IActionResult> PutRemoverTurmaAsync(
        [FromRoute] long avaliacaoId, [FromBody] RemoverTurmaCommand command)
    {
        if (avaliacaoId != command.AvaliacaoId) return BadRequest();

        var result = await Mediator.Send(command);

        return Ok(new Response(result, "Turma removida da avaliação com sucesso."));
    }
}