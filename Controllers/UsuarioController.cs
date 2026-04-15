using Microsoft.AspNetCore.Mvc;
using WebApplication2.Model;
using WebApplication2.Service;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("usuario")]
    public class UsuarioController: ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // ====================== GET ====================== //
        /*
         Para visualizar todos os usuários cadastrados
        */
        [HttpGet("visualizar")]
        public IActionResult Get()
        {
            var usuario = _usuarioService.GetAll();
            return new OkObjectResult(usuario);
        }

        /*
         Para visualizar um usuário em específico
        */
        [HttpGet("visualizar/{id}")]
        public IActionResult GetById(int id)
        {
            var usuario = _usuarioService.GetById(id);

            if (usuario == null)
            {
                return NotFound($"Usuário não encontrado. ID informado: {id}");
            }

            return Ok(usuario);
        }

        // ====================== POST ====================== //
        [HttpPost("adicionar")]
        public IActionResult Add([FromBody] UsuarioViewModel usuarioView)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var usuarioCriado = _usuarioService.Add(usuarioView);
                return CreatedAtAction(
                    nameof(GetById),
                    new { id = usuarioCriado.Id },
                    usuarioCriado);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao criar usuário: {ex.Message}");
            }
        }

        // ====================== DELETE ====================== //
        [HttpDelete("deletar/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _usuarioService.Delete(id);
                return Ok("Perfil removido com sucesso");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // ====================== PUT ====================== //
        [HttpPut("atualizar/{id}")]
        public IActionResult Update(int id, [FromBody] UsuarioViewModel usuarioView)
        {
            if (id != usuarioView.Id)
                return BadRequest("ID da URL não corresponde ao ID do corpo");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _usuarioService.Update(usuarioView);
                return Ok("Usuario atualizado com sucesso");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao atualizar usuário: {ex.Message}");
            }
        }

    }
}
