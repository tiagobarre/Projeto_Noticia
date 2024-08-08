using ProjetoNoticia.Domain.Entidades;
using ProjetoNoticia.Domain.Models.DTO;

namespace ProjetoNoticia.Repository.Interfaces
{
    public interface INoticiaRepository
    {
        Task<TratamentoDTO> CreateNoticia(Noticia request);
        Task<TratamentoDTO> CreateNoticiaTag(NoticiaTag request);
        Task<TratamentoDTO> CreateTag(Tag request);
        Task<TratamentoDTO> CreateUsuario(Usuario request);
        Task<TratamentoDTO> DeleteNoticia(int id);
        Task<TratamentoDTO> DeleteNoticiaTag(int id);
        Task<TratamentoDTO> DeleteTag(int id);
        Task<TratamentoDTO> DeleteUsuario(int id);
        Task<List<Noticia>> GetAllNoticia();
        Task<List<NoticiaTag>> GetAllNoticiaTags();
        Task<List<Tag>> GetAllTags();
        Task<List<Usuario>> GetAllUser();
        Task<Noticia> GetByIdNoticia(int id);
        Task<NoticiaTag> GetByIdNoticiaTag(int id);
        Task<Tag> GetByIdTag(int id);
        Task<Usuario> GetByIdUser(int id);
        Task<TratamentoDTO> UpdateNoticia(Noticia request);
        Task<TratamentoDTO> UpdateNoticiaTag(NoticiaTag request);
        Task<TratamentoDTO> UpdateTag(Tag request);
        Task<TratamentoDTO> UpdateUsuario(Usuario request);
    }
}