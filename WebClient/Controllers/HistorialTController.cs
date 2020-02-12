using Dominio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;


namespace WebClient.Controllers
{
    public class HistorialTController : Controller
    {
        // GET: HistorialT
        public ActionResult Index()
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:62233/");
            var request = clienteHttp.GetAsync("api/Youtube").Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<List<HistorialT>>(resultString);
                return View(listado);


            }
            return View(new List<HistorialT>());
        }

    }
}