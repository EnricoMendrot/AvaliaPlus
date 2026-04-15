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
    }
}
