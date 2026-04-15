using WebApplication2.Model;

namespace WebApplication2.ViewModel
{
    public class InstituicaoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cnpj { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public List<UsuarioViewModel> Usuarios { get; internal set; }
    }
}
