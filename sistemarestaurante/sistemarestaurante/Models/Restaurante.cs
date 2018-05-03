using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace sistemarestaurante.Models
{
    [Table("tabRestaurante")]
    public class Restaurante
    {
        [Key]
        [Column("codRestaurante")]
        [Display(Name = "Código")]
        public int codRestaurante { get; set; }
        [Column("nomeRestaurante")]
        [Display(Name="Nome")]
        public string nome { get; set; }
        [Column("DELETED")]
        [Display(Name="Deletado")]
        public bool deleted { get; set; }
        [NotMapped]
        public string Filtro { get; set; }

        //public virtual ICollection<Prato> Pratos { get; set; }
    }
}