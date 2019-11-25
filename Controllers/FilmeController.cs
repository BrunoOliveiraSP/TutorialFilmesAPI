using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieAPI.Models;

namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        Business.FilmeBusiness business = new Business.FilmeBusiness();
            

        [HttpPost]
        public ActionResult Inserir(Models.TbFilme filme)
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


        [HttpGet("{genero}")]
        public ActionResult<List<Models.TbFilme>> Consultar(string genero)
        {
            try
            {
                List<Models.TbFilme> filmes = business.Consultar(genero);
                return filmes;
            }
            catch (System.Exception ex)
            {
                ErrorModel erro = new ErrorModel(500, ex.Message);
                return StatusCode(500, erro);
            }
        }
        

        
        [HttpGet]
        public List<Models.TbFilme> ListarTodos()
        {
            List<Models.TbFilme> filmes = business.ListarTodos();
            return filmes;    
        }



        [HttpPut]
        public void Alterar(Models.TbFilme filme)
        {
            business.Alterar(filme);
        }



        [HttpDelete("{id}")]
        public void Remover(int id)
        {
            business.Remover(id);
        }


        

    }
}