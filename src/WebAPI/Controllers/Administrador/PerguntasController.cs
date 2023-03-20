using Biopark.CpaSurvey.Application.Perguntas.Commands.CriarPergunta;
using Biopark.CpaSurvey.Application.Perguntas.Queries.GetPergunta;
using Biopark.CpaSurvey.Application.Perguntas.Queries.GetPerguntas;
using Biopark.CpaSurvey.Infra.CrossCutting.Wrappers;
using Microsoft.AspNetCore.Mvc;

namespace Biopark.CpaSurvey.WebAPI.Controllers.Administrador;

public class PerguntasController : ApiController
{
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] CriarPerguntaCommand command)
    {
        var result = await Mediator.Send(command);
        return Created(
            "perguntas/",
            new Response(result, "Pergunta cadastrada com sucesso.")
        );
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync([FromQuery] GetPerguntasQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("{PerguntaId:long}")]
    public async Task<IActionResult> GetAsync([FromRoute] GetPerguntaQuery query)
    {
        var result = await Mediator.Send(query); 
        
        return Ok(result);
    }

    [HttpDelete("{PerguntaId:long}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] RemoverPerguntaCommand query)
    {
        var result = await Mediator.Send(query);

        return Ok(new Response(result, "Pergunta removida com sucesso."));
    }
}