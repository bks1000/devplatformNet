using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApp.Areas.BackControl.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /BackControl/Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            Session.Add(Common.Constant.BackSessionName, collection.GetValue("username").AttemptedValue);
            //return Redirect(Request.QueryString["from"]);//应采用这种方式
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /BackControl/Home/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /BackControl/Home/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /BackControl/Home/Create

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
        // GET: /BackControl/Home/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /BackControl/Home/Edit/5

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
        // GET: /BackControl/Home/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /BackControl/Home/Delete/5

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
