using WebApplication2.Infrastructure;
using WebApplication2.Model;

namespace WebApplication2.Repository
{
    public class PerfilRepository : IPerfilRepository
    {
        private readonly ConnectionContext _context;

        public PerfilRepository(ConnectionContext context)
        {
            _context = context;
        }

        public void Add(Perfil perfil)
        {
            _context.Perfil.Add(perfil);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var perfil = _context.Perfil.Find(id);

            if (perfil == null)
                return;

            _context.Perfil.Remove(perfil);
            _context.SaveChanges();
        }

        public List<Perfil> GetAll()
        {
            return _context.Perfil
                .OrderBy(p => p.Id)
                .ToList();
        }

        public Perfil? GetById(int id)
        {
            return _context.Perfil.Find(id);
        }

        public void Update(Perfil perfil)
        {
            var existente = _context.Perfil.Find(perfil.Id);

            if (existente == null)
                throw new KeyNotFoundException("Perfil não encontrado");

            existente.Nome = perfil.Nome;

            _context.SaveChanges();
        }
    }
}
