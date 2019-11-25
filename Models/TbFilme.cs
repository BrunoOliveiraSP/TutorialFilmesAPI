using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieAPI.Models
{
    [Table("tb_filme")]
    public partial class TbFilme
    {
        [Key]
        [Column("id_filme", TypeName = "int(11)")]
        public int IdFilme { get; set; }
        
        
        [Required]
        [Column("nm_filme", TypeName = "varchar(100)")]
        public string NmFilme { get; set; }
        
        
        [Required]
        [Column("ds_genero", TypeName = "varchar(100)")]
        public string DsGenero { get; set; }
        
        
        [Column("vl_avaliacao", TypeName = "decimal(15,2)")]
        public decimal VlAvaliacao { get; set; }
        
        
        [Column("bt_disponivel")]
        public bool BtDisponivel { get; set; }
        
        
        [Column("dt_estreia", TypeName = "datetime")]
        public DateTime DtEstreia { get; set; }
    }
}
