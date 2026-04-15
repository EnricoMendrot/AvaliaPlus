using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Model;
using WebApplication2.Service;
using WebApplication2.ViewModel;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("instituicao")]
    public class InstituicaoController : ControllerBase
    {
        private readonly InstituicaoService _instituicaoService;

        public InstituicaoController(InstituicaoService instituicaoService)
        {
            _instituicaoService = instituicaoService;
        }

        // ======================== POST ======================== //
        [HttpPost("adicionar")]
        public IActionResult Add([FromBody] InstituicaoCreateViewModel instituicaoView)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var instituicaoCriada = _instituicaoService.Add(instituicaoView);
                return CreatedAtAction(
                    nameof(GetById),
                    new { id = instituicaoCriada.Id },
                    instituicaoCriada);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar instituição: {ex.Message}");
            }
        }

        // ======================== GET ======================== //
        [HttpGet("visualizar")]
        public IActionResult Get()
        {
            var instituicao = _instituicaoService.GetAll();
            return new OkObjectResult(instituicao);
        }
        
        [HttpGet("visualizar/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var instituicao = _instituicaoService.GetById(id);
                if (instituicao == null)
                    return NotFound($"Instituição {id} não encontrada.");
                return Ok(instituicao);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar instituição: {ex.Message}");
            }
        }
    }
}
