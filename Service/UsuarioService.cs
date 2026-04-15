using WebApplication2.Model;
using WebApplication2.Repository;

namespace WebApplication2.Service
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // ====================== GET ====================== //

        public IEnumerable<Usuario> GetAll()
        {
            return _usuarioRepository.GetAll();
        }

        public Usuario? GetById(int id)
        {
            return _usuarioRepository.GetById(id);
        }

    }
}
