﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.UI.Process;
using ASF.Entities;
using ASF.UI.WbSite.Services.Cache;
using ASF.UI.WbSite.Constants.HomeController;

namespace ASF.UI.WbSite.Controllers
{
    public class CategoryController : Controller
    {
        [Route("category", Name = HomeControllerRoute.GetCategory)]
        public ActionResult Index()
        {
            //var cp = new CategoryProcess();
            var lista = DataCache.Instance.CategoryList();
            //return View(cp.SelectList());
            return View(lista);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category categoria)
        {
            try
            {
                var cp = new CategoryProcess();
                cp.insertCategory(categoria);
                DataCache.Instance.CategoryListRemove();
            
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            var cp = new CategoryProcess();

            return View(cp.findCategory(id));
        }

        public ActionResult Edit(int id)
        {
            var cp = new CategoryProcess();

            return View(cp.findCategory(id));
        }
        [HttpPost]
        public ActionResult Edit(Category categoria)
        {
            try
            {
                var cp = new CategoryProcess();
                cp.editCategory(categoria);
                DataCache.Instance.CategoryListRemove();
                return RedirectToAction("Index");
             }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var cp = new CategoryProcess();

            return View(cp.findCategory(id));
        }
        [HttpPost]
        public ActionResult Delete(int id, Category categoria)
        {
            try
            {
                var cp = new CategoryProcess();
                cp.deleteCategory(id);
                DataCache.Instance.CategoryListRemove();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}