using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace sistemarestaurante.Models
{
    public class Context : DbContext
    {
        public Context()
            : base("DefaultConnection")
        {
        }

        public DbSet<Restaurante> Restaurante { get; set; }
        public DbSet<Prato> Prato { get; set; }
    }
}