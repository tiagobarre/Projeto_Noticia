using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;

namespace ProjetoNoticia.Entidades
{
    [Table("Noticia")]
    public class Noticia
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(250)]
        public string Titulo { get; set; }
        public string Texto { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
    }

}
