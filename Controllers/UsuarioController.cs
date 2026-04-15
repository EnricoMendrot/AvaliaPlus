using Microsoft.AspNetCore.Mvc;
using WebApplication2.Service;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("usuario")]
    public class UsuarioController
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
    }
}
