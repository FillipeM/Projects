using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace sistemarestaurante.Models
{
    public class RestauranteModel
    {
        public List<Restaurante> GetALL(string nome)
        {
            using (Context context = new Context())
            {
                return context.Restaurante.Where(f => (f.nome.ToLower() == nome.ToLower() || string.IsNullOrEmpty(nome)) && f.deleted == false).ToList();
            }
        }

        public int CriarRestaurante(Restaurante obj)
        {
            using (Context context = new Context())
            {
                obj = context.Restaurante.Add(obj);

                context.SaveChanges();
                return obj.codRestaurante;
            }
        }

        public void AtualizarRestaurante(int codRestaurante, string nome, bool deleted = false)
        {
            using (Context context = new Context())
            {
                Restaurante obj = context.Restaurante.Find(codRestaurante);
                obj.nome = nome;
                obj.deleted = deleted;
                context.SaveChanges();
            }

        }

        public void DeleteRestaurante(Restaurante obj)
        {
            PratoModel objPratoModel = new PratoModel();
            obj.deleted = true;
            List<Prato> listPratos = objPratoModel.BuscarPorRestaurante(obj.codRestaurante);
            if (listPratos != null && listPratos.Count > 0)
            {
                foreach (Prato objPrato in listPratos)
                {
                    objPratoModel.Apagar(objPrato);
                }
            }
            AtualizarRestaurante(obj.codRestaurante, obj.nome, obj.deleted);
        }

        public Restaurante BuscarPorCodigo(int codRestaurante)
        {
            using (Context context = new Context())
            {
                return context.Restaurante.Find(codRestaurante);
            }
        }
    }
}