using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoNoticia.Domain.Entidades
{
    [Table("Tag")]
    public class Tag
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Descricao { get; set; }
    }
}
