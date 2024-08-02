using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoNoticia.Entidades;
using ProjetoNoticia.Models.DTO;
using ProjetoNoticia.Repositories;
using System.Diagnostics;

namespace ProjetoNoticia.Controllers
{
    public class HomeController : Controller
    {        
        private readonly NoticiaRepository _noticiaRepository;   

        public HomeController(NoticiaRepository noticiaRepository)
        {
            _noticiaRepository = noticiaRepository;            
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cadastro()
        {
            return View();
        }
               

        [HttpGet]
        [Route("GetAllNoticia")]
        public async Task<IActionResult> GetAllNoticia()
        {
            try
            {
                var resp = await _noticiaRepository.GetAllNoticia();
                if (resp.Count() == 0)
                    return BadRequest("Nenhum dado encontrato");
                else
                    return Ok(resp.OrderByDescending(x => x.Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        [HttpGet]
        [Route("GetAllNoticiaTag")]
        public async Task<IActionResult> GetAllNoticiaTag()
        {
            try
            {
                var resp = await _noticiaRepository.GetAllNoticiaTags();
                if (resp.Count() == 0)
                    return BadRequest("Nenhum dado encontrato");
                else
                    return Ok(resp.OrderByDescending(x => x.Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("GetByIdNoticia")]
        public async Task<IActionResult> GetByIdNoticia(int id)
        {
            try
            {
                var resp = await _noticiaRepository.GetByIdNoticia(id);
                if (resp == null)
                    return BadRequest("Nenhum dado encontrato");
                else
                    return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
          
        }

        [HttpGet]
        [Route("GetByIdTag")]
        public async Task<IActionResult> GetByIdTag(int id)
        {
            try
            {
                var resp = await _noticiaRepository.GetByIdTag(id);
                if (resp == null)
                    return BadRequest("Nenhum dado encontrato");
                else
                    return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("GetByIdTagNoticia")]
        public async Task<IActionResult> GetByIdTagNoticia(int id)
        {
            try
            {
                var resp = await _noticiaRepository.GetByIdNoticiaTag(id);
                if (resp == null)
                    return BadRequest("Nenhum dado encontrato");
                else
                    return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Route("CreateUsuario")]
        public async Task<JsonResult> CreateUsuario([FromBody]UsuarioRequestDTO obj)
        {
            try
            {          
                var resp = await _noticiaRepository.CreateUsuario(new Usuario { Email = obj.Email, Nome = obj.Nome, Senha = obj.Senha });
                if (resp.Status)
                    return Json(resp);
                else
                    return Json(resp);

            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }

        [HttpPost]
        [Route("CreateTag")]
        public async Task<JsonResult> CreateTag([FromBody] Tag obj)
        {
            try
            {
                var resp = new TratamentoDTO();

                if (obj.Id == 0)
                     resp = await _noticiaRepository.CreateTag(obj);
                else
                    resp = await _noticiaRepository.UpdateTag(obj);
                if (resp.Status)
                    return Json(resp);
                else
                    return Json(resp);

            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }

        [HttpPost]
        [Route("CreateNoticia")]
        public async Task<JsonResult> CreateNoticia([FromBody] Noticia obj)
        {
            try
            {
                var resp = new TratamentoDTO();

                if (obj.Id == 0)
                    resp = await _noticiaRepository.CreateNoticia(obj);
                else
                    resp = await _noticiaRepository.UpdateNoticia(obj);

                if (resp.Status)
                    return Json(resp);
                else
                    return Json(resp);

            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }

        [HttpPost]
        [Route("CreateNoticiaTag")]
        public async Task<JsonResult> CreateNoticiaTag([FromBody] NoticiaTag obj)
        {
            try
            {
                var resp = new TratamentoDTO();

                if (obj.Id == 0)
                    resp = await _noticiaRepository.CreateNoticiaTag(obj);
                else
                    resp = await _noticiaRepository.UpdateNoticiaTag(obj);

                if (resp.Status)
                    return Json(resp);
                else
                    return Json(resp);

            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }

        [HttpDelete]
        [Route("DeteleNoticia")]
        public async Task<JsonResult> DeteleNoticia(int id)
        {
            try
            {
                var resp = await _noticiaRepository.DeleteNoticia(id);
                if (resp.Status)
                    return Json(resp);
                else
                    return Json(resp);

            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }

        [HttpDelete]
        [Route("DeteleTag")]
        public async Task<JsonResult> DeteleTag(int id)
        {
            try
            {
                var resp = await _noticiaRepository.DeleteTag(id);
                if (resp.Status)
                    return Json(resp);
                else
                    return Json(resp);

            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }
        
        [HttpDelete]
        [Route("DeteleTagNoticia")]
        public async Task<JsonResult> DeteleTagNoticia(int id)
        {
            try
            {
                var resp = await _noticiaRepository.DeleteNoticiaTag(id);
                if (resp.Status)
                    return Json(resp);
                else
                    return Json(resp);

            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }

        [HttpGet]
        [Route("GetAllTags")]
        public async Task<IActionResult> GetAllTags()
        {
            try
            {
                var resp = await _noticiaRepository.GetAllTags();
                if (resp.Count() == 0)
                    return BadRequest("Nenhum dado encontrato");
                else
                    return Ok(resp.OrderByDescending(x => x.Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
