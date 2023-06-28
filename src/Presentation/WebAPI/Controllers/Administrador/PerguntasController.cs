using Biopark.CpaSurvey.Application.Perguntas.Queries.GetPergunta;
using Biopark.CpaSurvey.Application.Perguntas.Queries.GetPerguntas;
using Biopark.CpaSurvey.Application.Perguntas.Commands.CorrigirDescricao;
using Biopark.CpaSurvey.Application.Perguntas.Commands.CorrigirEixo;
using Biopark.CpaSurvey.Application.Perguntas.Commands.CorrigirTipoResposta;
using Biopark.CpaSurvey.Infra.CrossCutting.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Biopark.CpaSurvey.Application.Perguntas.Commands.CriarPergunta;
using Biopark.CpaSurvey.Application.Perguntas.Commands.RemoverPergunta;

namespace Biopark.CpaSurvey.WebAPI.Controllers.Administrador;

public class PerguntasController : ApiController
{
    [HttpPost]
    [SwaggerOperation("Cadastra uma nova pergunta.")]
    public async Task<IActionResult> PostPerguntaAsync([FromBody] CriarPerguntaCommand command)
    {
        var result = await Mediator.Send(command);
        return Created(
            "perguntas/",
            new Response(result, "Pergunta cadastrada com sucesso.")
        );
    }

    [HttpGet]
    [SwaggerOperation("Retorna todas as perguntas cadastradas.")]
    public async Task<IActionResult> GetPerguntasAsync([FromQuery] GetPerguntasQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("{perguntaId:long}")]
    [SwaggerOperation("Retorna uma pergunta através do identificador provido.")]
    public async Task<IActionResult> GetAsync([FromRoute] GetPerguntaQuery query)
    {
        var result = await Mediator.Send(query); 
        
        return Ok(result);
    }

    [HttpPut("{perguntaId:long}/corrigir-descricao")]
    [SwaggerOperation("Corrige a descrição de uma pergunta através do identificador provido.")]
    public async Task<IActionResult> PutCorrigirDescricaoPerguntaAsync(
        [FromRoute] long perguntaId, [FromBody] CorrigirDescricaoPerguntaCommand command)
    {
        if (perguntaId != command.PerguntaId) return BadRequest();

        var result = await Mediator.Send(command);

        return Ok(new Response(result, "Descrição da pergunta corrigido com sucesso."));
    }

    [HttpPut("{perguntaId:long}/corrigir-tipo-resposta")]
    [SwaggerOperation("Corrige o tipo de resposta de uma pergunta através do identificador provido.")]
    public async Task<IActionResult> PutCorrigirTipoRespostaPerguntaAsync(
        [FromRoute] long perguntaId, [FromBody] CorrigirTipoRespostaPerguntaCommand command)
    {
        if (perguntaId != command.PerguntaId) return BadRequest();

        var result = await Mediator.Send(command);

        return Ok(new Response(result, "Tipo de resposta da pergunta corrigido com sucesso."));
    }

    [HttpPut("{perguntaId:long}/corrigir-eixo")]
    [SwaggerOperation("Corrige o eixo de uma pergunta através dos identificadores providos.")]
    public async Task<IActionResult> PutCorrigirEixoPerguntaAsync(
        [FromRoute] long perguntaId, [FromBody] CorrigirEixoPerguntaCommand command)
    {
        if (perguntaId != command.PerguntaId) return BadRequest();

        var result = await Mediator.Send(command);

        return Ok(new Response(result, "Eixo da pergunta corrigido com sucesso."));
    }

    [HttpDelete("{perguntaId:long}")]
    [SwaggerOperation("Remove uma pergunta através do identificador provido.")]
    public async Task<IActionResult> DeletePerguntaAsync([FromRoute] RemoverPerguntaCommand query)
    {
        var result = await Mediator.Send(query);

        return Ok(new Response(result, "Pergunta removida com sucesso."));
    }
}