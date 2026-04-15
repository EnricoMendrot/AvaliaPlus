using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Model
{
    [Table("Instituicao")]
    public class Instituicao
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        [Column("CNPJ")]
        public string Cnpj { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public List<Usuario> Usuarios { get; set; } = new List<Usuario>();
        public List<Curso> Curso { get; set; } = new List<Curso>();

        public Instituicao()
        {
            
        }
        public Instituicao(string nome, string cnpj, string cidade, string estado)
        {
            Nome = nome;
            Cnpj = cnpj;
            Cidade = cidade;
            Estado = estado;
        }


    }
}
