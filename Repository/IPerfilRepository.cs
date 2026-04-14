using WebApplication2.Model;

namespace WebApplication2.Repository
{
    public interface IPerfilRepository
    {
        List<Perfil> GetAll();
        Perfil? GetById(int id);
        void Add(Perfil perfil);
        void Update(Perfil perfil);
    }
}
