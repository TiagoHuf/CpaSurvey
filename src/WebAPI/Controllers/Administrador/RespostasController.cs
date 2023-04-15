using Biopark.CpaSurvey.Application.Perguntas.Commands.CriarPergunta;
using Biopark.CpaSurvey.Application.Respostas.Queries.GetRespostas;
using Biopark.CpaSurvey.Application.Respostas.Queries.GetResposta;
using Biopark.CpaSurvey.Infra.CrossCutting.Wrappers;
using Microsoft.AspNetCore.Mvc;

namespace Biopark.CpaSurvey.WebAPI.Controllers.Administrador;

public class RespostasController : ApiController
{
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SalvarRespostaCommand command)
    {
        var result = await Mediator.Send(command);
        return Created(
            "resposta/",
            new Response(result, "Respostas salvas com sucesso.")
        );
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync([FromQuery] GetRespostasQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("{RespostaId:long}")]
    public async Task<IActionResult> GetAsync([FromRoute] GetRespostaQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

}