using System;

namespace MovieAPI.Models
{
    public class FilmeResponse
    {
        public int IdFilme { get; set; }
        public string NmFilme { get; set; }
        public string DsGenero { get; set; }
        public decimal VlAvaliacao { get; set; }
        public bool BtDisponivel { get; set; }
        public DateTime DtEstreia { get; set; }


        public string NmDiretor { get; set; }


        public int QtdAtores { get; set; }

        
    }
}