using System.ComponentModel.DataAnnotations;

namespace ProjetoNoticia.Models.DTO
{
    public class UsuarioRequestDTO
    {
        
        public string Nome { get; set; }

        
        public string Senha { get; set; }

        
        public string Email { get; set; }
    }
}
