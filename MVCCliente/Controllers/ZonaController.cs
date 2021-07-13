using BusinessLogic.Controllers;
using Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCliente.Controllers
{
    public class ZonaController : Controller
    {
        // GET: Zona
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult cargarZonasBD()
        {
            BLZonaController BLZ = new BLZonaController();
            List<DtoZona> colZonas = BLZ.listarZonas();
            return Json(colZonas, JsonRequestBehavior.AllowGet);
        }
    }
}