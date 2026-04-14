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
    }
}
