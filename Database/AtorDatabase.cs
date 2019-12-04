using System.Linq;
using System.Collections.Generic;

namespace MovieAPI.Database
{
    public class AtorDatabase
    {
        Models.moviedbContext db = new Models.moviedbContext();

        public void Inserir(Models.TbAtor ator)
        {
            db.TbAtor.Add(ator);
            db.SaveChanges();
        }

        public List<Models.TbAtor> Consultar(int idFilme)
        {
            List<Models.TbAtor> atores = db.TbAtor.Where(x => x.IdFilme == idFilme)
                                                  .ToList();
            return atores;
        }
    }
}