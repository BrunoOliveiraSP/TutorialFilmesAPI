using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MovieAPI.Business
{
    public class FilmeBusiness
    {
        Database.AtorDatabase dbAtor = new Database.AtorDatabase();
        Database.FilmeDatabase dbFilme = new Database.FilmeDatabase();        
        Database.DiretorDatabase dbDiretor = new Database.DiretorDatabase();        
        


        public void Inserir(Models.FilmeRequest request)
        {
            this.ValidarFilme(request.Filme);
            this.ValidarAtores(request.Atores);
            this.ValidarDiretor(request.Diretor);
            
            // Insere filme
            dbFilme.Inserir(request.Filme);

            // Vincula filme em diretor e insere
            request.Diretor.IdFilme = request.Filme.IdFilme;
            dbDiretor.Inserir(request.Diretor);
            
            // Para cada ator, vincula filme em diretor e insere
            foreach (Models.TbAtor ator in request.Atores)
            {
                ator.IdFilme = request.Filme.IdFilme;
                dbAtor.Inserir(ator);
            }
        }


        private void ValidarFilme(Models.TbFilme filme)
        {
            if (filme.NmFilme.Length < 3)
                throw new ArgumentException("Nome é obrigatório.");
        }

        private void ValidarDiretor(Models.TbDiretor diretor)
        {
            if (diretor.NmDiretor.Length < 3)
                throw new ArgumentException("Nome é obrigatório.");
        }

        private void ValidarAtores(List<Models.TbAtor> atores)
        {
            foreach (Models.TbAtor ator in atores)
            {
                if (ator.NmAtor.Length < 3)
                    throw new ArgumentException("Nome é obrigatório.");
            }
        }



        public List<Models.FilmeResponse> ConsultarPorNome(string nome)
        {
            // Busca Filmes
            List<Models.TbFilme> filmes = dbFilme.ConsultarPorNome(nome);

            // Cria lista de resposta
            List<Models.FilmeResponse> response = new List<Models.FilmeResponse>();
            
            // Converte cada objeto filme, em objeto response
            foreach (Models.TbFilme filme in filmes)
            {
                Models.FilmeResponse r = CriarResponse(filme);
                response.Add(r);
            }
            return response;
        }

        private Models.FilmeResponse CriarResponse(Models.TbFilme filme)
        {
            Models.FilmeResponse response = new Models.FilmeResponse();
            response.IdFilme = filme.IdFilme;
            response.NmFilme = filme.NmFilme;
            response.DsGenero = filme.DsGenero;
            response.DtEstreia = filme.DtEstreia;
            response.VlAvaliacao = filme.VlAvaliacao;
            response.BtDisponivel = filme.BtDisponivel;
            
            if (filme.TbDiretor.Count > 0)
                response.NmDiretor = filme.TbDiretor.FirstOrDefault().NmDiretor;

            if (filme.TbAtor.Count > 0)
                response.QtdAtores = filme.TbAtor.Count();

            return response;
        }






















        public void Inserir(Models.TbFilme filme)
        {
            if (filme.NmFilme.Length < 3)
                throw new ArgumentException("Nome é obrigatório.");
            
            if (filme.DsGenero == string.Empty)
                throw new ArgumentException("Gênero é obrigatório.");
                
            dbFilme.Inserir(filme);
        }

        public void Alterar(Models.TbFilme filme)
        {
            if (filme.IdFilme == 0)
                throw new ArgumentException("Id inválido");

            if (filme.NmFilme.Length < 3)
                throw new ArgumentException("Nome é obrigatório.");
            
            if (filme.DsGenero == string.Empty)
                throw new ArgumentException("Gênero é obrigatório.");
                
            dbFilme.Alterar(filme);
        }

        public void Remover(int id)
        {
            if (id == 0)
                throw new ArgumentException("Id inválido");

            dbFilme.Remover(id);
        }

        public List<Models.TbFilme> ListarTodos()
        {
            return dbFilme.ListarTodos();
        }

        public List<Models.TbFilme> Consultar(string genero)
        {
            if (genero.Length < 3)
                throw new ArgumentException("Gênero inválido.");

            return dbFilme.Consultar(genero);
        }

    }
}