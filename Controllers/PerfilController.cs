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

        [HttpGet("visualizar")]
        public IActionResult Get()
        {
            var perfil = _perfilRepository.GetAll();
            return Ok(perfil);
        }
    }
}
