using Biopark.CpaSurvey.Application.Alunos.Commands.CriarAluno;
using Biopark.CpaSurvey.Application.Alunos.Commands.RemoverAluno;
using Biopark.CpaSurvey.Application.Alunos.Queries.GetALuno;
using Biopark.CpaSurvey.Application.Alunos.Queries.GetAlunos;
using Biopark.CpaSurvey.Infra.CrossCutting.Wrappers;
using Microsoft.AspNetCore.Mvc;

namespace Biopark.CpaSurvey.WebAPI.Controllers.Administrador;
public class AlunosController : ApiController
{
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] CriarAlunoCommand command)
    {
        var result = await Mediator.Send(command);
        return Created(
            "Alunos/",
            new Response(result, "Aluno cadastrado com sucesso.")
        );
    }

    [HttpGet("{AlunoId:long}")]
    public async Task<IActionResult> GetAsync([FromRoute] GetAlunoQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync([FromQuery] GetAlunosQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpDelete("{AlunoId:long}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] RemoverAlunoCommand query)
    {
        var result = await Mediator.Send(query);

        return Ok(new Response(result, "Aluno removida com sucesso."));
    }
}
