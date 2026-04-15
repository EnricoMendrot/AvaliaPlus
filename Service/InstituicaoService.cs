using Microsoft.EntityFrameworkCore;
using WebApplication2.Infrastructure;
using WebApplication2.Model;
using WebApplication2.Repository.Interfaces;
using WebApplication2.ViewModel;

namespace WebApplication2.Service
{
    public class InstituicaoService
    {
        private readonly IInstituicaoRepository _instituicaoRepository;

        public InstituicaoService(IInstituicaoRepository instituicaoRepository)
        {
            _instituicaoRepository = instituicaoRepository;
        }

        // ======================== POST ======================== //
        public InstituicaoViewModel Add(InstituicaoCreateViewModel instituicaoView)
        {
            if (instituicaoView == null)
                throw new ArgumentNullException(nameof(instituicaoView));

            var instituicao = new Instituicao
            {
                Nome = instituicaoView.Nome.Trim(),
                Cnpj = instituicaoView.Cnpj.Trim(),
                Cidade = instituicaoView.Cidade.Trim(),
                Estado = instituicaoView.Estado.Trim()
            };

            try
            {
                _instituicaoRepository.Add(instituicao);

                return new InstituicaoViewModel
                {
                    Id = instituicao.Id,
                    Nome = instituicao.Nome,
                    Cnpj = instituicao.Cnpj,
                    Cidade = instituicao.Cidade,
                    Estado = instituicao.Estado
                };
            }
            catch (DbUpdateException ex) when (ex.InnerException != null)
            {
                throw new Exception($"Erro ao salvar instituição: {ex.InnerException.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao criar instituição: {ex.Message}", ex);
            }
        }

        // ======================== GET ======================== //
        public InstituicaoViewModel? GetById(int id)
        {
            var instituicao = _instituicaoRepository.GetById(id);
            if (instituicao == null) return null;

            return new InstituicaoViewModel
            {
                Id = instituicao.Id,
                Nome = instituicao.Nome,
                Cnpj = instituicao.Cnpj,
                Cidade = instituicao.Cidade,
                Estado = instituicao.Estado,
                Usuarios = instituicao.Usuarios.Select(u => new UsuarioViewModel
                {
                    Id = u.Id,
                    Nome = u.Nome,
                    Email = u.Email
                }).ToList()
            };
        }
    }
}
