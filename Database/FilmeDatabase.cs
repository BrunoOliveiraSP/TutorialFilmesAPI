using System.Linq;
using System.Linq.Expressions;
using System.Collections;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MovieAPI.Database
{
    public class FilmeDatabase
    {
        Models.moviedbContext db = new Models.moviedbContext();

        public void Inserir(Models.TbFilme filme)
        {
            db.TbFilme.Add(filme);
            db.SaveChanges();
        }

        public void Alterar(Models.TbFilme filme)
        {
            Models.TbFilme alterado = db.TbFilme.FirstOrDefault(x => x.IdFilme == filme.IdFilme);
            alterado.NmFilme = filme.NmFilme;
            alterado.DsGenero = filme.DsGenero;
            alterado.BtDisponivel = filme.BtDisponivel;
            alterado.DtEstreia = filme.DtEstreia;
            alterado.VlAvaliacao = filme.VlAvaliacao;

            db.SaveChanges();
        }

        public void Remover(int id)
        {
            Models.TbFilme remover = db.TbFilme.FirstOrDefault(x => x.IdFilme == id);

            db.TbFilme.Remove(remover);
            db.SaveChanges();
        }

        public List<Models.TbFilme> ListarTodos()
        {
            List<Models.TbFilme> filmes = db.TbFilme
                                            .ToList();
            return filmes;
        }

        public List<Models.TbFilme> ConsultarPorNome(string nome)
        {
            List<Models.TbFilme> filmes = db.TbFilme
                                            .Include(x => x.TbAtor)     // inclui Atores no resultado
                                            .Include(x => x.TbDiretor)  // inclui Diretor no resultado
                                            .Where(x => x.NmFilme.Contains(nome))
                                            .ToList();
            return filmes;
        }

        public List<Models.TbFilme> Consultar(string genero)
        {
            List<Models.TbFilme> filmes = db.TbFilme.Where(x => x.DsGenero.Contains(genero))
                                                    .ToList();
            return filmes;
        }
    }
}