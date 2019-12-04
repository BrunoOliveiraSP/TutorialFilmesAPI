using System.Linq;
using System.Collections.Generic;

namespace MovieAPI.Database
{
    public class DiretorDatabase
    {
        Models.moviedbContext db = new Models.moviedbContext();

        public void Inserir(Models.TbDiretor diretor)
        {
            db.TbDiretor.Add(diretor);
            db.SaveChanges();
        }

        public Models.TbDiretor Consultar(int idFilme)
        {
            Models.TbDiretor diretor = db.TbDiretor.FirstOrDefault(x => x.IdFilme == idFilme);
            return diretor;
        }
    }
}