using System.ComponentModel.DataAnnotations;

namespace WebApplication2.ViewModel
{
    public class InstituicaoCreateViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CNPJ é obrigatório")]
        public string Cnpj { get; set; } = string.Empty;

        public string Cidade { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
    }
}
