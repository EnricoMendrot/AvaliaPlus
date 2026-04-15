using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Model
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]                                           // ← Obrigatório
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Senha { get; set; } = string.Empty;
        public int PerfilId { get; set; }
        public Perfil Perfil { get; set; }
        public int? InstituicaoId { get; set; }
        public Instituicao Instituicao { get; set; }
        public int? CursoId { get; set; }
        public Curso Curso { get; set; }

        public Usuario()
        {

        }

        public Usuario(string nome, string email, string senha, int perfilId, Perfil perfil, int? instituicaoId, int? cursoId)
        { 
            Nome = nome;
            Email = email;
            Senha = senha;
            PerfilId = perfilId;
            InstituicaoId = instituicaoId;
            CursoId = cursoId;
        }
    }
}
