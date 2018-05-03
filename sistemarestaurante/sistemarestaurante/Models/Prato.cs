using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace sistemarestaurante.Models
{
    [Table("tabPrato")]
    public class Prato
    {
        [Key]
        [Column("codPrato")]
        [Required]
        [Display(Name="Código")]
        public int Codigo { get; set; }
        [Column("codRestaurante")]
        //[Required]
        [Display(Name = "Restaurante")]
        public int Restaurante { get; set; }
        [Column("nomePrato")]
        [Required]
        [Display(Name="Nome")]
        public string Nome { get; set; }
        [Column("valor")]
        [Required]
        [DataType(DataType.Currency)]
        [Display(Name="Valor")]
        public decimal Valor{ get; set; }
        [Column("DELETED")]
        [Display(Name="Deletado")]
        public bool Deleted { get; set; }

    }
}