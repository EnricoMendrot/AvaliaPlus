using Microsoft.EntityFrameworkCore;
using WebApplication2.Model;
using WebApplication2.Repository;
using WebApplication2.Security;

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

        // ====================== POST ====================== //

        public Usuario Add(UsuarioViewModel usuarioView)
        {
            if (usuarioView == null)
                throw new ArgumentNullException(nameof(usuarioView));

            if (string.IsNullOrWhiteSpace(usuarioView.Senha))
                throw new ArgumentException("A senha é obrigatória");

            var usuario = new Usuario
            {
                Nome = usuarioView.Nome.Trim(),
                Email = usuarioView.Email.Trim().ToLower(),
                Senha = PasswordHasher.HashPassword(usuarioView.Senha),                    // ← idealmente com hash
                PerfilId = usuarioView.PerfilId,
                InstituicaoId = usuarioView.InstituicaoId,
                CursoId = usuarioView.CursoId
            };

            try
            {
                _usuarioRepository.Add(usuario);
                return usuario;
            }
            catch (DbUpdateException ex) when (ex.InnerException != null)
            {
                // Isso vai mostrar o erro real no console ou log
                throw new Exception($"Erro ao salvar usuário: {ex.InnerException.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao criar usuário: {ex.Message}", ex);
            }
        }
    }
}
