using WebApplication2.Infrastructure;
using Microsoft.EntityFrameworkCore;
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

        public List<Perfil> GetAll()
        {
            return _context.Perfil.ToList();
        }

        public Perfil? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Perfil perfil)
        {
            throw new NotImplementedException();
        }
    }
}
