using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApiDemo.Controllers
{
    public class HandleErrorController : Controller
    {
        // GET: HandleError
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NotFound()
        {
            return View();
        }

        public ActionResult InternalServerError()
        {
            return View();
        }
    }
}