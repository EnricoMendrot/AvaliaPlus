using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Model  
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Nome deve ter entre 3 e 100 caracteres")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; } = string.Empty;

        public string? Senha { get; set; }   // opcional no ViewModel (não retorna senha do banco)

        public int PerfilId { get; set; }

        public int? InstituicaoId { get; set; }

        public int? CursoId { get; set; }




    }
}