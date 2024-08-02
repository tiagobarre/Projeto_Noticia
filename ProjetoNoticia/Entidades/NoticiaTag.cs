using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoNoticia.Entidades
{
    [Table("NoticiaTag")]
    public class NoticiaTag
    {
        [Key]
        public int Id { get; set; }
        public int NoticiaId { get; set; }

        [ForeignKey("Tag")]
        public int TagId { get; set; }
    }
}
