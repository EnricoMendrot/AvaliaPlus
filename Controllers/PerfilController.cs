 using Microsoft.AspNetCore.Mvc;
using WebApplication2.Model;
using WebApplication2.Repository;
using WebApplication2.Service;
using WebApplication2.ViewModel;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("perfil")]
    public class PerfilController : ControllerBase
    {
        private readonly PerfilService _perfilService;

        public PerfilController(PerfilService perfilService)
        {
            _perfilService = perfilService;
        }

        /*
         Serve para adicionar um novo perfil
         */
        [HttpPost("adicionar")]
        public IActionResult Add(PerfilViewModel perfilView)
        {
            try
            {
                var perfil = _perfilService.Add(perfilView);
                return Ok(perfil);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /*
         Serve para visualizar todos os perfis
         */

        [HttpGet("visualizar")]
        public IActionResult Get()
        {
            var perfil = _perfilService.GetAll();
            return Ok(perfil);
        }

        /*
         Serve para visualizar cada perfil por Id
         */
        [HttpGet("visualizar/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var perfil = _perfilService.GetById(id);
                return Ok(perfil);
            }
            catch (KeyNotFoundException ex)
            {

                return NotFound($"Perfil não encontrado. ID informado: {id}. Detalhe: {ex.Message}");
            }

        }

        [HttpPut("atualizar/{id}")]
        public IActionResult Update(int id, PerfilViewModel perfilView)
        {
            try
            {
                _perfilService.Update(id, perfilView);
                return Ok("Perfil atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
