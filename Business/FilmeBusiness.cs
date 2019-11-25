using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MovieAPI.Business
{
    public class FilmeBusiness
    {
        Database.FilmeDatabase db = new Database.FilmeDatabase();        


        public void Inserir(Models.TbFilme filme)
        {
            if (filme.NmFilme.Length < 3)
                throw new ArgumentException("Nome é obrigatório.");
            
            if (filme.DsGenero == string.Empty)
                throw new ArgumentException("Gênero é obrigatório.");
                
            db.Inserir(filme);
        }

        public void Alterar(Models.TbFilme filme)
        {
            if (filme.IdFilme == 0)
                throw new ArgumentException("Id inválido");

            if (filme.NmFilme.Length < 3)
                throw new ArgumentException("Nome é obrigatório.");
            
            if (filme.DsGenero == string.Empty)
                throw new ArgumentException("Gênero é obrigatório.");
                
            db.Alterar(filme);
        }

        public void Remover(int id)
        {
            if (id == 0)
                throw new ArgumentException("Id inválido");

            db.Remover(id);
        }

        public List<Models.TbFilme> ListarTodos()
        {
            return db.ListarTodos();
        }

        public List<Models.TbFilme> Consultar(string genero)
        {
            if (genero.Length < 3)
                throw new ArgumentException("Gênero inválido.");

            return db.Consultar(genero);
        }

    }
}