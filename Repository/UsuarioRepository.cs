using WebApplication2.Infrastructure;
using WebApplication2.Model;

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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

    }
}
