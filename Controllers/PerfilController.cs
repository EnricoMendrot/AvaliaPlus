 using Microsoft.AspNetCore.Mvc;
using WebApplication2.Model;
using WebApplication2.Repository;
using WebApplication2.ViewModel;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("perfil")]
    public class PerfilController : ControllerBase
    {
        private readonly IPerfilRepository _perfilRepository;

        public PerfilController(IPerfilRepository perfilRepository)
        {
            _perfilRepository = perfilRepository ?? throw new ArgumentNullException(nameof(perfilRepository));
        }

        /*
         Serve para adicionar um novo perfil
         */
        [HttpPost("adicionar")]
        public IActionResult Add(PerfilViewModel perfilView)
        {
            var perfil = new Perfil(perfilView.Nome);
            _perfilRepository.Add(perfil);
            return Ok(perfil);
        }

        /*
         Serve para visualizar todos os perfis
         */

        [HttpGet("visualizar")]
        public IActionResult Get()
        {
            var perfil = _perfilRepository.GetAll();
            return Ok(perfil);
        }

        /*
         Serve para visualizar cada perfil por Id
         */
        [HttpGet("visualizar/{id}")]
        public IActionResult GetById(int id)
        {
            var perfil = _perfilRepository.GetById(id);
            if (perfil == null)
            {
                return NotFound();
            }
            return Ok(perfil);

        }

        [HttpPut("atualizar/{id}")]
        public IActionResult Update(int id, PerfilViewModel perfilView)
        {
            try
            {
                if (id != perfilView.Id || _perfilRepository.GetById(id) == null)
                {
                    return BadRequest("O ID do perfil não corresponde ao ID fornecido.");
                }

                var perfil = new Perfil(perfilView.Nome)
                {
                    Id = id
                };

                _perfilRepository.Update(perfil);

                return Ok(perfil);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }

        }
    }
}
