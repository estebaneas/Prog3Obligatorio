using BusinessLogic.Controllers;
using Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCControlReclamos.Controllers
{
    public class TipoReclamoController : Controller
    {

        public ActionResult ListarReclamos()
        {
            BLTipoDeReclamoController BLTdR = new BLTipoDeReclamoController();
            List<DtoTipoReclamo> colTipoReclamo = BLTdR.getTiposDeReclamos();
            return View(colTipoReclamo);
        }

        public ActionResult Agregar()
        {
            return View();
        }
        public ActionResult AgregarTipoReclamo(DtoTipoReclamo dtoTipoReclamo)
        {
            BLTipoDeReclamoController BLTdR = new BLTipoDeReclamoController();
            BLTdR.agregarTipoReclamo(dtoTipoReclamo);

            return RedirectToAction("ListarReclamos");
        }
    }
}
