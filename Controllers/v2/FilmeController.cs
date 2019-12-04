using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieAPI.Models;


namespace MovieAPI.Controllers.v2
{
    [ApiController]
    [Route("v2/[controller]")]
    public class FilmeController : ControllerBase
    {
        Business.FilmeBusiness business = new Business.FilmeBusiness();
            

        [HttpPost]
        public ActionResult Inserir(Models.FilmeRequest filme)
        {
            try
            {
                business.Inserir(filme);

                return Ok();
            }
            catch (System.Exception ex)
            {
                ErrorModel erro = new ErrorModel(500, ex.Message);
                return StatusCode(500, erro);
            }
        }


        [HttpGet("{nome}")]
        public List<Models.FilmeResponse> Consultar(string nome)
        {
            List<Models.FilmeResponse> filmes = business.ConsultarPorNome(nome);
            return filmes;
        }

        
        [HttpGet]
        public List<Models.FilmeResponse> Listar()
        {
            List<Models.FilmeResponse> filmes = business.ConsultarPorNome(string.Empty);
            return filmes;
        }


    }
}