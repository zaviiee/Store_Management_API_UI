﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreManagement.Controllers
{
    public class ErrorHandlingController : Controller
    {
        // GET: ErrorHandling
        public ActionResult Error()
        {
            return View();
        }
    }
}