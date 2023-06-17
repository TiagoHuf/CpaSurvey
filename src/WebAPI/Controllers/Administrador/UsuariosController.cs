using Biopark.CpaSurvey.Application.Eixos.Commands.CriarPergunta;
using Biopark.CpaSurvey.Application.Perguntas.Commands.CorrigirDescricao;
using Biopark.CpaSurvey.Application.Perguntas.Commands.CorrigirEixo;
using Biopark.CpaSurvey.Application.Perguntas.Commands.CorrigirTipoResposta;
using Biopark.CpaSurvey.Application.Perguntas.Queries.GetPergunta;
using Biopark.CpaSurvey.Application.Perguntas.Queries.GetPerguntas;
using Biopark.CpaSurvey.Application.Usuarios.Commands.CorrigirLogin;
using Biopark.CpaSurvey.Application.Usuarios.Commands.CorrigirRole;
using Biopark.CpaSurvey.Application.Usuarios.Commands.CorrigirSenha;
using Biopark.CpaSurvey.Application.Usuarios.Commands.CriarUsuario;
using Biopark.CpaSurvey.Application.Usuarios.Commands.RemoverUsuario;
using Biopark.CpaSurvey.Application.Usuarios.Queries.GetUsuario;
using Biopark.CpaSurvey.Application.Usuarios.Queries.GetUsuarios;
using Biopark.CpaSurvey.Infra.CrossCutting.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Biopark.CpaSurvey.WebAPI.Controllers.Administrador;

public class UsuariosController : ApiController
{
    [HttpPost]
    [SwaggerOperation("Cadastra um novo usuario.")]
    public async Task<IActionResult> PostUsuarioAsync([FromBody] CriarUsuarioCommand command)
    {
        var result = await Mediator.Send(command);
        return Created(
            "usuarios/",
            new Response(result, "Usario cadastrado com sucesso.")
        );
    }

    [HttpGet]
    [SwaggerOperation("Retorna todas os usuarios cadastrados.")]
    public async Task<IActionResult> GetPerguntasAsync([FromQuery] GetUsuariosQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("{usuarioId:long}")]
    [SwaggerOperation("Retorna um usuario através do identificador provido.")]
    public async Task<IActionResult> GetAsync([FromRoute] GetUsuarioQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpPut("{usuarioId:long}/corrigir-login")]
    [SwaggerOperation("Corrige o login de um usuario através do identificador provido.")]
    public async Task<IActionResult> PutCorrigirLoginUsuarioAsync(
        [FromRoute] long usuarioId, [FromBody] CorrigirLoginUsuarioCommand command)
    {
        if (usuarioId != command.UsarioId) return BadRequest();

        var result = await Mediator.Send(command);

        return Ok(new Response(result, "Login do usuario corrigido com sucesso."));
    }

    [HttpPut("{usuarioId:long}/corrigir-senha")]
    [SwaggerOperation("Corrige a senha de um usuario através do identificador provido.")]
    public async Task<IActionResult> PutCorrigirSenhaUsuarioAsync(
        [FromRoute] long usuarioId, [FromBody] CorrigirSenhaUsuarioCommand command)
    {
        if (usuarioId != command.UsarioId) return BadRequest();

        var result = await Mediator.Send(command);

        return Ok(new Response(result, "Senha do usuario corrigido com sucesso."));
    }

    [HttpPut("{usuarioId:long}/corrigir-role")]
    [SwaggerOperation("Corrige a role de um usuario através dos identificadores providos.")]
    public async Task<IActionResult> PutCorrigirRoleUsuarioAsync(
        [FromRoute] long usuarioId, [FromBody] CorrigirRoleUsuarioCommand command)
    {
        if (usuarioId != command.UsarioId) return BadRequest();

        var result = await Mediator.Send(command);

        return Ok(new Response(result, "Role do usuario corrigido com sucesso."));
    }

    [HttpDelete("{usuarioId:long}")]
    [SwaggerOperation("Remove um usuario através do identificador provido.")]
    public async Task<IActionResult> DeleteUsuarioAsync([FromRoute] RemoverUsuarioCommand query)
    {
        var result = await Mediator.Send(query);

        return Ok(new Response(result, "Usuario removido com sucesso."));
    } 
}