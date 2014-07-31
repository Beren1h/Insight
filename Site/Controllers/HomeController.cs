using Newtonsoft.Json;
using Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Site.Controllers
{
    public class HomeController : Controller
    {
        //public async Task<ActionResult> Index()
        public ActionResult Index()
        {
            //return View("Index", await GetEntry());
            return View();
        }

        public async Task<Entry> GetEntry()
        {
            var uri = "http://insight.org:8001/api/ledger/get/53d3a22dd5c9041618ea45a6";

            using (HttpClient client = new HttpClient())
            {
                return JsonConvert.DeserializeObject<Entry>( await client.GetStringAsync(uri));
            }
        }
    }
}