using Newtonsoft.Json;
using ProjetoBT2018_1.Models;
using ProjetoBT2018_1.Models.Dominio;
using ProjetoBT2018_1.Models.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoBT2018_1.Controllers
{
    public class UsuarioController : Controller
    {
        private HttpCookie cookie;

        public ActionResult Index()
        {
            cookie = Request.Cookies["Login"];
            if (cookie != null)
            {
                return View(new MaquinaController().GetAllMachines(int.Parse(cookie.Values["User"])));
            }

            return RedirectToAction("Login", "Home");
        }
    }
}