using sistemarestaurante.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sistemarestaurante.Controllers
{
    public class RestauranteController : Controller
    {
        //
        // GET: /Restaurante/
        private static RestauranteModel objModel = new RestauranteModel();
        public ActionResult Restaurantes(string Filtro = "")
        {
            return View(objModel.GetALL(Filtro));
        }

        public ActionResult CadastroRestaurante(int? id = null)
        {
            Restaurante obj = null;
            if (!id.HasValue)
                obj = new Restaurante();
            else
                obj = objModel.BuscarPorCodigo(id.Value);
            return View(obj);
        }

        [HttpPost]
        public ActionResult CadastroRestaurante(Restaurante obj)
        {
            obj.deleted = false;
            if (obj.codRestaurante == 0)
                objModel.CriarRestaurante(obj);
            else
                Editar(obj);

            return RedirectToAction("Restaurantes");
        }
        
        public ActionResult Editar(int codRestaurante)
        {
            Restaurante obj = objModel.BuscarPorCodigo(codRestaurante);
            return View("CadastroRestaurante", obj);
        }

        [HttpPost]
        public void Editar(Restaurante objRestaurante)
        {
            if (objRestaurante != null)
            {
                objModel.AtualizarRestaurante(objRestaurante.codRestaurante, objRestaurante.nome);
            }
        }

        public ActionResult Apagar(int id)
        {
            Restaurante obj = objModel.BuscarPorCodigo(id);
            if (obj != null)
            {
                return View(obj);
            }
            return HttpNotFound();
        }

        [HttpPost, ActionName("Apagar")]
        public ActionResult ApagarConfirm(int id)
        {
            Restaurante obj = objModel.BuscarPorCodigo(id);
            objModel.DeleteRestaurante(obj);
            return RedirectToAction("Restaurantes");
        }
    }
}
