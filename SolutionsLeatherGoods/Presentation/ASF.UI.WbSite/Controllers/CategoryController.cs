using ASF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASF.UI.WbSite.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            var categoryProcess = new UI.Process.CategoryProcess();
            return View(categoryProcess.SelectList());
        }

        [HttpPost]
        public ActionResult Create(Category nuevaCategoria)
        {
            var categoryProcess = new UI.Process.CategoryProcess();
            categoryProcess.insertCategory(nuevaCategoria);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Search(Category categoria)
        //{
        //    var categoryProcess = new UI.Process.CategoryProcess();
        //    return View(categoryProcess.findCategory(categoria));
            
        //}

        [HttpGet]
        public ActionResult Search()
        {
            return View();

        }



    }
}