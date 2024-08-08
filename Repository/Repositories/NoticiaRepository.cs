using Microsoft.EntityFrameworkCore;
using ProjetoNoticia.Infra.DAO;
using ProjetoNoticia.Domain.Entidades;
using ProjetoNoticia.Domain.Models.DTO;
using ProjetoNoticia.Repository.Interfaces;

namespace ProjetoNoticia.Repository.Repositories
{
    public class NoticiaRepository : INoticiaRepository
    {
        private readonly ProjetoNoticiaContext _context;

        public NoticiaRepository(ProjetoNoticiaContext context)
        {
            _context = context;
        }

        #region ListarAll
        public async Task<List<Noticia>> GetAllNoticia()
        {
            return await _context.Noticia.ToListAsync();
        }

        public async Task<List<Usuario>> GetAllUser()
        {
            return await _context.Usuario.ToListAsync();
        }

        public async Task<List<Tag>> GetAllTags()
        {
            return await _context.Tag.ToListAsync();
        }

        public async Task<List<NoticiaTag>> GetAllNoticiaTags()
        {
            return await _context.NoticiaTag.ToListAsync();
        }
        #endregion

        #region ListarByID
        public async Task<Noticia> GetByIdNoticia(int id)
        {
            return await _context.Noticia.Where(x => x.Id == id).FirstAsync();
        }

        public async Task<Usuario> GetByIdUser(int id)
        {
            return await _context.Usuario.Where(x => x.Id == id).FirstAsync();
        }

        public async Task<Tag> GetByIdTag(int id)
        {
            return await _context.Tag.Where(x => x.Id == id).FirstAsync();
        }

        public async Task<NoticiaTag> GetByIdNoticiaTag(int id)
        {
            return await _context.NoticiaTag.Where(x => x.Id == id).FirstAsync();
        }
        #endregion

        #region Create
        public async Task<TratamentoDTO> CreateNoticia(Noticia request)
        {
            try
            {
                _context.Noticia.Add(request);
                await _context.SaveChangesAsync();

                return new TratamentoDTO { Status = false, Mensagem = "Noticia criada com sucesso." };
            }
            catch (Exception ex)
            {
                return new TratamentoDTO { Status = false, Mensagem = ex.Message };
            }

        }


        public async Task<TratamentoDTO> CreateNoticiaTag(NoticiaTag request)
        {
            try
            {
                _context.NoticiaTag.Add(request);
                await _context.SaveChangesAsync();

                return new TratamentoDTO { Status = false, Mensagem = "Noticia tag criada com sucesso." };
            }
            catch (Exception ex)
            {
                return new TratamentoDTO { Status = false, Mensagem = ex.Message };
            }

        }

        public async Task<TratamentoDTO> CreateUsuario(Usuario request)
        {
            try
            {
                var resp = _context.Usuario.Where(x => request.Nome.Contains(x.Nome)).FirstOrDefault();

                if (resp != null)
                {
                    resp.Senha = request.Senha;
                    resp.Nome = request.Nome;
                    resp.Email = request.Email;

                    _context.Entry(resp).State = EntityState.Modified;
                }
                else
                    _context.Usuario.Add(request);

                await _context.SaveChangesAsync();

                return new TratamentoDTO { Status = false, Mensagem = "Usuario salvo com sucesso." };
            }
            catch (Exception ex)
            {
                return new TratamentoDTO { Status = false, Mensagem = ex.Message };
            }

        }

        public async Task<TratamentoDTO> CreateTag(Tag request)
        {
            try
            {
                _context.Tag.Add(request);
                await _context.SaveChangesAsync();

                return new TratamentoDTO { Status = false, Mensagem = "Tag criada com sucesso." };
            }
            catch (Exception ex)
            {
                return new TratamentoDTO { Status = false, Mensagem = ex.Message };
            }

        }
        #endregion

        #region Update
        public async Task<TratamentoDTO> UpdateNoticia(Noticia request)
        {
            try
            {
                await _context.Noticia.AddAsync(request);
                _context.Noticia.Entry(request).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return new TratamentoDTO { Status = false, Mensagem = "Noticia salva com sucesso." };
            }
            catch (Exception ex)
            {
                return new TratamentoDTO { Status = false, Mensagem = ex.Message };
            }

        }

        public async Task<TratamentoDTO> UpdateNoticiaTag(NoticiaTag request)
        {
            try
            {
                await _context.NoticiaTag.AddAsync(request);
                _context.NoticiaTag.Entry(request).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return new TratamentoDTO { Status = false, Mensagem = "NoticiaTag salva com sucesso." };
            }
            catch (Exception ex)
            {
                return new TratamentoDTO { Status = false, Mensagem = ex.Message };
            }

        }

        public async Task<TratamentoDTO> UpdateTag(Tag request)
        {
            try
            {
                await _context.Tag.AddAsync(request);
                _context.Tag.Entry(request).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return new TratamentoDTO { Status = false, Mensagem = "Tag salva com sucesso." };
            }
            catch (Exception ex)
            {
                return new TratamentoDTO { Status = false, Mensagem = ex.Message };
            }

        }

        public async Task<TratamentoDTO> UpdateUsuario(Usuario request)
        {
            try
            {
                await _context.Usuario.AddAsync(request);
                _context.Usuario.Entry(request).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return new TratamentoDTO { Status = false, Mensagem = "Usuario salvo com sucesso." };
            }
            catch (Exception ex)
            {
                return new TratamentoDTO { Status = false, Mensagem = ex.Message };
            }

        }

        #endregion

        #region Delete
        public async Task<TratamentoDTO> DeleteNoticia(int id)
        {
            try
            {
                var resp = _context.Noticia.Where(x => x.Id == id).FirstOrDefault();
                _context.Entry(resp).State = EntityState.Deleted;
                await _context.SaveChangesAsync();

                return new TratamentoDTO { Status = false, Mensagem = "Noticia criada com sucesso." };
            }
            catch (Exception ex)
            {
                return new TratamentoDTO { Status = false, Mensagem = ex.Message };
            }

        }

        public async Task<TratamentoDTO> DeleteTag(int id)
        {
            try
            {
                var resp = _context.Tag.Where(x => x.Id == id).FirstOrDefault();
                _context.Entry(resp).State = EntityState.Deleted;
                await _context.SaveChangesAsync();

                return new TratamentoDTO { Status = false, Mensagem = "Noticia criada com sucesso." };
            }
            catch (Exception ex)
            {
                return new TratamentoDTO { Status = false, Mensagem = ex.Message };
            }

        }

        public async Task<TratamentoDTO> DeleteUsuario(int id)
        {
            try
            {
                var resp = _context.Usuario.Where(x => x.Id == id).FirstOrDefault();
                _context.Entry(resp).State = EntityState.Deleted;
                await _context.SaveChangesAsync();

                return new TratamentoDTO { Status = false, Mensagem = "Noticia criada com sucesso." };
            }
            catch (Exception ex)
            {
                return new TratamentoDTO { Status = false, Mensagem = ex.Message };
            }

        }

        public async Task<TratamentoDTO> DeleteNoticiaTag(int id)
        {
            try
            {
                var resp = _context.NoticiaTag.Where(x => x.Id == id).FirstOrDefault();
                _context.Entry(resp).State = EntityState.Deleted;
                await _context.SaveChangesAsync();

                return new TratamentoDTO { Status = false, Mensagem = "Noticia criada com sucesso." };
            }
            catch (Exception ex)
            {
                return new TratamentoDTO { Status = false, Mensagem = ex.Message };
            }

        }

        #endregion


    }
}
