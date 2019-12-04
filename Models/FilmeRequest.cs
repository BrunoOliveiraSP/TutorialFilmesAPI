using System.Collections.Generic;

namespace MovieAPI.Models
{
    public class FilmeRequest
    {
        public Models.TbFilme Filme { get; set; }
        public Models.TbDiretor Diretor { get; set; }
        public List<Models.TbAtor> Atores { get; set; }
    }
}