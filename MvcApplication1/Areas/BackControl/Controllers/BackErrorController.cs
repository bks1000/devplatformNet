using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApp.Areas.BackControl.Controllers
{
    public class BackErrorController : Controller
    {
        //
        // GET: /BackControl/BackError/

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
