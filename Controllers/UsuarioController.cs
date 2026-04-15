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
    }
}
