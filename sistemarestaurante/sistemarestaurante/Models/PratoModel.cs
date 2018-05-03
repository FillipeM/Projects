using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sistemarestaurante.Models
{
    public class PratoModel
    {
        public List<Prato> GetALL(string Filtro = "")
        {
            using (Context context = new Context())
            {
                return context.Prato.Where(f => (string.IsNullOrEmpty(Filtro) || f.Nome.ToLower() == Filtro.ToLower()) && f.Deleted == false).ToList();
            }
        }

        public Prato BuscarPorCodigo(int codPrato)
        {
            using (Context context = new Context())
            {
                return context.Prato.Find(codPrato);
            }
        }

        public void Inserir(Prato objPrato)
        {
            using (Context context = new Context())
            {
                context.Prato.Add(objPrato);
                context.SaveChanges();
            }
        }

        public void Atualizar(int codPrato, int restaurante, string nome, decimal valor, bool deleted = false)
        {
            using (Context context = new Context())
            {
                Prato objPrato = context.Prato.Find(codPrato);
                objPrato.Restaurante = restaurante;
                objPrato.Nome = nome;
                objPrato.Valor = valor;
                objPrato.Deleted = deleted;

                context.SaveChanges();
            }
        }

        public void Apagar(Prato objPrato)
        {
            Atualizar(objPrato.Codigo, objPrato.Restaurante, objPrato.Nome, objPrato.Valor, true);
        }

        public List<Prato> BuscarPorRestaurante(int codRestaurante)
        {
            using (Context context = new Context())
            {
                return context.Prato.Where(f => f.Restaurante == codRestaurante).ToList();
            }
        }
    }
}