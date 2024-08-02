using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoNoticia.Entidades
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(250)]
        public string Nome { get; set; }

        [MaxLength(50)]
        public string Senha { get; set; }

        [MaxLength(250)]
        public string Email { get; set; }
    }
}
