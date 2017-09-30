﻿using System;
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

        public ActionResult NotFound()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

        
    }
}
