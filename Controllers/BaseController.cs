﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApiDemo.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);    
        }
    }
}