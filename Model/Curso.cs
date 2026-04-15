using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Model
{
    [Table("Curso")]
    public class Curso
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int InstituicaoId { get; set; }
        public Instituicao Instituicao { get; set; }

        public Curso()
        {
            
        }

        public Curso(string name, int instituicaoId)
        {
            Name = name;
            InstituicaoId = instituicaoId;
        }

    }
}
