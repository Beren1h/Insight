using Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site.Controllers
{
    public class LedgerController : Controller
    {
        public LedgerController()
        {

        }

        public ActionResult Index()
        {
            //var pay = new DateTime(2014, 08, 15);
            //var next = pay.AddDays(14);

            //var now = DateTime.Now;
            //var day = 2;

            //var asDate = new DateTime(2014, now.Month, day);
            
            //if (DateTime.Compare(asDate, now) < 0)
            //{
            //    asDate = asDate.AddMonths(1);
            //}





            //var model = new Ledger { Pay = pay, Next = next, AsDate = asDate };





            return View();
        }
    }
}