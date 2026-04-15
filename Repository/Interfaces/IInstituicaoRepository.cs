using WebApplication2.Model;

namespace WebApplication2.Repository.Interfaces
{
    public interface IInstituicaoRepository
    {
        IEnumerable<Instituicao> GetAll();
        Instituicao? GetById(int id);
        void Add(Instituicao Instituicao);
        void Update(Instituicao Instituicao);
        void Delete(int id);
    }
}
