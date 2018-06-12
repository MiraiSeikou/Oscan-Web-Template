using AutoMapper;
using Newtonsoft.Json;
using ProjetoBT2018_1.Models;
using ProjetoBT2018_1.Models.Dominio;
using ProjetoBT2018_1.Models.Dominios;
using ProjetoBT2018_1.Models.Repositorios;
using ProjetoBT2018_1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ProjetoBT2018_1.Controllers


{
    



    public class MaquinaController : Controller

    {
        HttpCookie cookie;

        public ActionResult Maquina(int idMaquina)
        {

            cookie = Request.Cookies["Login"];
            cookie.Values.Set("Maquina", idMaquina.ToString());
            Response.Cookies.Set(cookie);

            return View(new BcMaquina().GetMachineContext(idMaquina));
        }

        public List<DominioMaquina> GetAllMachines(int idUsuario)
        {
            var response = new ApiRepositorio().Get(string.Format("api/Maquinas/IdUsuario/{0}", idUsuario));
            var save = response.Content.ReadAsAsync<List<DominioMaquina>>().Result;
            return save;
        }

        // GET: Processor
        public double GetProcessor(int idMaquina)
        {
            return new BcMaquina().GetProcessor(idMaquina);
        }

        public ActionResult Relatorio(int idMaquina)
        {
            return View(new BcMaquina().GetRelatorio(idMaquina));
        }

        public string GetMemorias(int idMaquina)
        {
            string response = JsonConvert.SerializeObject(new BcMaquina().GetMemoria(idMaquina));
            return response;
        }

    }
}