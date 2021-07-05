using BusinessLogic.Controllers;
using Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCliente.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        [HttpGet]
        public ActionResult cargarZonasBD()
        {
            BLZonaController BLZ = new BLZonaController();
            List<DtoZona> colZonas = BLZ.listarZonas();
            return Json(colZonas, JsonRequestBehavior.AllowGet);
        }


       /*public ActionResult puntoEnZona (DtoPunto punto)
        {
            BLZonaController BLZ = new BLZonaController();
            List<DtoZona> colZonas = BLZ.listarZonas();
            bool puntoEnZ = BLZ.puntoEnZonas(punto, colZonas);

            return Json()
        }*/

        public ActionResult Prueba()
        {
            return View();
        }
    }
}