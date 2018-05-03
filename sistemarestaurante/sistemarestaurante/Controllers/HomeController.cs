using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sistemarestaurante.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "SISTEMA DE CADASTRO DE RESTAURANTES";
            ViewBag.Title = "Página Inicial";
            return View();
        }

        public ActionResult Restaurantes()
        {
            ViewBag.Message = "Restaurantes";

            return View();
        }

        public ActionResult Pratos()
        {
            ViewBag.Message = "Pratos";

            return View();
        }

        public ActionResult CadastroRestaurante()
        {
            ViewBag.Message = "Cadastro de Restaurantes";

            return View();
        }

        public ActionResult CadastroPratos()
        {
            ViewBag.Message = "Cadastro de Pratos";

            return View();
        }
    }
}
