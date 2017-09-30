using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;

namespace MvcApp.Controllers
{
    public class HttpErrorController : Controller
    {
        //
        // GET: /HttpError/

        public ActionResult Show(string id)
        {
            ViewBag.code = id;
            return View();
        }

        //
        // GET: /HttpError/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /HttpError/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /HttpError/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /HttpError/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /HttpError/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /HttpError/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /HttpError/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
