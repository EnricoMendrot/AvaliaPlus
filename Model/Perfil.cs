using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Model
{
    [Table("Perfil")]
    public class Perfil
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty; // "Aluno", "Administrador", "Professor"
        public Perfil()
        {
            
        }
        public Perfil(string nome)
        {
            this.Nome = nome;
        }
    }
}
