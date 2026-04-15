using WebApplication2.Model;
using WebApplication2.Repository.Interfaces;
using WebApplication2.ViewModel;

namespace WebApplication2.Service
{
    public class PerfilService
    {
        private readonly IPerfilRepository _perfilRepository;

        public PerfilService(IPerfilRepository perfilRepository)
        {
            _perfilRepository = perfilRepository;
        }

        /*
         Para adicionar as informações
        */
        public Perfil Add(PerfilViewModel perfilView)
        {
            if (string.IsNullOrWhiteSpace(perfilView.Nome))
                throw new Exception("Nome é obrigatório");

            var perfil = new Perfil(perfilView.Nome);

            _perfilRepository.Add(perfil);

            return perfil;
        }

        /*
         Para pegar todos os perfis do banco de dados
        */
        public List<Perfil> GetAll()
        {
            return _perfilRepository.GetAll();
        }

        /*
         Para pegar perfil por ID
        */
        public Perfil GetById(int id)
        {
            var existente = _perfilRepository.GetById(id);

            if (existente == null)
                throw new Exception("Perfil não encontrado");

            return existente;
        }

        /*
         Para atualizar as informações
         */
        public void Update(int id, PerfilViewModel perfilView)
        {

            var existente = _perfilRepository.GetById(id);

            if (existente == null)
                throw new Exception("Perfil não encontrado");

            existente.Nome = perfilView.Nome;

            _perfilRepository.Update(existente);
        }

        public void Delete(int id)
        {
            var perfil = _perfilRepository.GetById(id);

            if (perfil == null)
                throw new Exception("Pefil não encontrado");

            _perfilRepository.Delete(id);
        }
    }
}
