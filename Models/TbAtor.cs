using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieAPI.Models
{
    [Table("tb_ator")]
    public partial class TbAtor
    {
        [Key]
        [Column("id_ator", TypeName = "int(11)")]
        public int IdAtor { get; set; }
        [Required]
        [Column("nm_ator", TypeName = "varchar(100)")]
        public string NmAtor { get; set; }
        [Required]
        [Column("ds_pais", TypeName = "varchar(100)")]
        public string DsPais { get; set; }
        [Column("id_filme", TypeName = "int(11)")]
        public int IdFilme { get; set; }

        [ForeignKey(nameof(IdFilme))]
        [InverseProperty(nameof(TbFilme.TbAtor))]
        public virtual TbFilme IdFilmeNavigation { get; set; }
    }
}
