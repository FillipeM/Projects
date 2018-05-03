using sistemarestaurante.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sistemarestaurante.Controllers
{
    public class PratoController : Controller
    {
        //
        // GET: /Prato/

        public ActionResult Pratos()
        {
            PratoModel objModel = new PratoModel();
            ViewBag.Title = "PRATOS";
            return View(objModel.GetALL());
        }

        public ActionResult CadastroPrato(int? id = null)
        {
            PratoModel objModel = new PratoModel();
            RestauranteModel objRestModel = new RestauranteModel();
            Prato objPrato = null;
            if (!id.HasValue)
                objPrato = new Prato();
            else
                objPrato = objModel.BuscarPorCodigo(id.Value);
            ViewBag.Title = "CADASTRO DE PRATOS";
            ViewBag.Restaurantes = objRestModel.GetALL("");
            return View(objPrato);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastroPrato(Prato obj)
        {
            PratoModel objModel = new PratoModel();
            obj.Deleted = false;
            if (obj.Codigo == 0)
                objModel.Inserir(obj);
            else
                Editar(obj);

            return RedirectToAction("Pratos");
        }

        public void Editar(Prato objPrato)
        {
            PratoModel objModel = new PratoModel();
            objModel.Atualizar(objPrato.Codigo, objPrato.Restaurante, objPrato.Nome, objPrato.Valor);
        }

        public ActionResult Apagar(int id)
        {
            PratoModel objModel = new PratoModel();
            Prato obj = objModel.BuscarPorCodigo(id);
            if (obj != null)
            {
                return View(obj);
            }

            return HttpNotFound();
        }

        [HttpPost, ActionName("Apagar")]
        [ValidateAntiForgeryToken]
        public ActionResult ApagarConfirm(int id)
        {
            PratoModel objModel = new PratoModel();
            Prato obj = objModel.BuscarPorCodigo(id);
            objModel.Apagar(obj);
            return RedirectToAction("Pratos");
        }

    }
}
