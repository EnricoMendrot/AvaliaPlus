using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WebApplication2.Infrastructure;
using WebApplication2.Model;
using WebApplication2.Repository.Interfaces;

namespace WebApplication2.Repository.Implementations
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        private readonly ConnectionContext _context;

        public InstituicaoRepository(ConnectionContext context)
        {
            _context = context;
        }

        public void Add(Instituicao instituicao)
        {
            _context.Instituicao.Add(instituicao);
            _context.SaveChanges();

        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Instituicao> GetAll()
        {
            throw new NotImplementedException();
        }

        public Instituicao? GetById(int id)
        {
            return _context.Instituicao
                .Include(i => i.Usuarios)
                // .Include(i => i.Cursos)
                .FirstOrDefault(i => i.Id == id);
        }

        public void Update(Instituicao Instituicao)
        {
            throw new NotImplementedException();
        }
    }
}
