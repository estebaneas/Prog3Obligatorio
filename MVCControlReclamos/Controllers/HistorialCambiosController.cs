﻿using MVCControlReclamos.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCControlReclamos.Controllers
{
    [UserAuthentication]
    public class HistorialCambiosController : Controller
    {
        // GET: HistorialCambios
        public ActionResult Index()
        {
            return View();
        }
    }
}