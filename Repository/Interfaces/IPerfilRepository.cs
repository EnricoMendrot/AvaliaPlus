using WebApplication2.Model;

namespace WebApplication2.Repository.Interfaces
{
    public interface IPerfilRepository
    {
        List<Perfil> GetAll();
        Perfil? GetById(int id);
        void Add(Perfil perfil);
        void Update(Perfil perfil);
        void Delete(int id);
    }
}
