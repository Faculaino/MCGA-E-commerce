using ASF.Entities;
using ASF.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASF.UI.WbSite.Controllers
{
    public class DealerController : Controller
    {
        
        public ActionResult Index()
        {
            var dProcess = new DealerProcess();
            return View(dProcess.SelectList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            var categoria = new CategoryProcess().SelectList();
            var pais = new CountryProcess().SelectList();

            ViewBag.Category = new SelectList(categoria, "Id", "Name");
            ViewBag.Country = new SelectList(pais, "Id", "Name");

            return View();
        }

        [HttpPost]
        public ActionResult Create(Dealer dealer, string Category, string Country)
        {
            var dProcess = new DealerProcess();
            dealer.CategoryId = Int32.Parse(Category);
            dealer.CountryId = Int32.Parse(Country);
            dProcess.InsertDealer(dealer);

            return RedirectToAction("Index");
        }
    }
}