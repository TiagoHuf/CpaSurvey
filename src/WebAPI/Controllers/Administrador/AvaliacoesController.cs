using Biopark.CpaSurvey.Application.Avaliacoes.Commands.CriarAvalicao;
using Biopark.CpaSurvey.Application.Avaliacoes.Commands.RemoverAvaliacao;
using Biopark.CpaSurvey.Application.Avaliacoes.Queries.GetAvaliacao;
using Biopark.CpaSurvey.Application.Avaliacoes.Queries.GetAvaliacoes;
using Biopark.CpaSurvey.Infra.CrossCutting.Wrappers;
using Microsoft.AspNetCore.Mvc;

namespace Biopark.CpaSurvey.WebAPI.Controllers.Administrador;

public class AvaliacoessController : ApiController
{
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] CriarAvaliacaoCommand command)
    {
        var result = await Mediator.Send(command);
        return Created(
            "avaliação/",
            new Response(result, "Avaliação cadastrada com sucesso.")
        );
    }

    [HttpGet("{AvaliacaoId:long}")]
    public async Task<IActionResult> GetAsync([FromRoute] GetAvaliacaoQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync([FromQuery] GetAvaliacoesQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpDelete("{AvaliacaoId:long}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] RemoverAvaliacaoCommand query)
    {
        var result = await Mediator.Send(query);

        return Ok(new Response(result, "Avaliação removida com sucesso."));
    }
}
