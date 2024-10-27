using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using WebApi_LivroseAutores.DTO.Autor;
using WebApi_LivroseAutores.Models;
using WebApi_LivroseAutores.Services.Autor;

namespace WebApi_LivroseAutores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly AutorInterface _autorInterface;
        public AutorController(AutorInterface autorInterface)
        {
            _autorInterface = autorInterface;
        }

        [HttpGet("ListarAutores")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ListarAutores()
        {
            var autores = await _autorInterface.ListarAutores();
            return Ok(autores);
        }

        [HttpGet("BuscarAutorPorId/{id}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorId(int id)
        {
            var autor = await _autorInterface.BuscarAutorPorId(id); // Passa o ID para o método do serviço
            if (autor == null)
            {
                return NotFound(new ResponseModel<AutorModel>
                {
                    Mensagem = "Autor não encontrado",
                    Status = false
                });
            }

            return Ok(autor);
        }

        [HttpGet("BuscarAutorPorIdLivro/{idLivro}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorIdLivro(int idLivro)
        {
            var autor = await _autorInterface.BuscarAutorPorIdLivro(idLivro);
            if (autor == null)
            {
                return NotFound(new ResponseModel<AutorModel>
                {
                    Mensagem = "Autor não encontrado",
                    Status = false
                });
            }

            return Ok(autor);
        }

        [HttpPost("CriarAutor")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> CriarAutor(AutorCriacaoDto autorCriacaoDto)
        {
            var autores = await _autorInterface.CriarAutor(autorCriacaoDto);
            return Ok(autores);
        }


        [HttpDelete("ExcluirAutor/{id}")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ExcluirAutor(int id)
        {
            var resultado = await _autorInterface.ExcluirAutor(id);

            if (!resultado.Status)
            {
                return NotFound(resultado);
            }

            return Ok(resultado);
        }

        [HttpPut("EditarAutor/{id}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> EditarAutor( AutorEdicaoDto autorEdicaoDto)
        {
            var resultado = await _autorInterface.EditarAutor( autorEdicaoDto); 

            if (!resultado.Status)
            {
                return NotFound(resultado);  
            }

            return Ok(resultado);  
        }


    }
}
