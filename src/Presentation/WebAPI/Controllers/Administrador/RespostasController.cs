using Biopark.CpaSurvey.Application.Respostas.Queries.GetRespostas;
using Biopark.CpaSurvey.Application.Respostas.Queries.GetResposta;
using Biopark.CpaSurvey.Infra.CrossCutting.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;
using Biopark.CpaSurvey.Application.Respostas.Commands.SalvarResposta;
using Biopark.CpaSurvey.Application.Respostas.Queries.GetAvaliacoesAluno;

namespace Biopark.CpaSurvey.WebAPI.Controllers.Administrador;

public class RespostasController : ApiController
{
    [HttpPost]
    [SwaggerOperation("Cadastra uma resposta.")]
    public async Task<IActionResult> PostRespostaAsync(
        [FromBody] SalvarRespostaCommand command)
    {
        var result = await Mediator.Send(command);
        return Created(
            "respostas/",
            new Response(result, "Resposta salva com sucesso.")
        );
    }

    [HttpGet]
    [SwaggerOperation("Retorna todas as respostas cadastradas.")]
    public async Task<IActionResult> GetRespostasAsync([FromQuery] GetRespostasQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("{respostaId:long}")]
    [SwaggerOperation("Retorna uma resposta através do identificador provido.")]
    public async Task<IActionResult> GetRespostaAsync([FromRoute] GetRespostaQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("avaliacoes-aluno")]
    [SwaggerOperation("Retorna as avaliações que um aluno da sessão deve responder.")]
    public async Task<IActionResult> GetAvaliacoesAlunoAsync([FromQuery] GetAvaliacoesAlunoQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }
}