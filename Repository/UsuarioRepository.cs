using Microsoft.EntityFrameworkCore;
using WebApplication2.Infrastructure;
using WebApplication2.Model;
using WebApplication2.Security;

namespace WebApplication2.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ConnectionContext _context;

        public UsuarioRepository(ConnectionContext context)
        {
            _context = context;
        }

        public void Add(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var usuario = _context.Usuario.Find(id);

            if (usuario == null)
                return;

            _context.Usuario.Remove(usuario);
            _context.SaveChanges();
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _context.Usuario
                .OrderBy(u => u.Id)
                .ToList(); 
        }

        public Usuario? GetById(int id)
        {
            return _context.Usuario.Find(id);
        }

        public void Update(Usuario usuario)
        {
            if (usuario?.Id <= 0)
                throw new ArgumentException("ID inválido");

            // Busca a entidade já rastreada no contexto local
            var local = _context.Usuario.Local
                .FirstOrDefault(u => u.Id == usuario.Id);

            // Se encontrar, desatacha para evitar conflito
            if (local != null)
                _context.Entry(local).State = EntityState.Detached;

            _context.Usuario.Attach(usuario);
            _context.Entry(usuario).State = EntityState.Modified;
            _context.Entry(usuario).Property(u => u.Id).IsModified = false;

            if (string.IsNullOrWhiteSpace(usuario.Senha))
            {
                _context.Entry(usuario).Property(u => u.Senha).IsModified = false;
            }
            else
            {
                usuario.Senha = PasswordHasher.HashPassword(usuario.Senha);
            }

            _context.SaveChanges();
        }

    }
}
