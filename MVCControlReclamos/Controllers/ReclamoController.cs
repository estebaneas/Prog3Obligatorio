using BusinessLogic.Controllers;
using Common.DTOs;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCControlReclamos.Controllers
{
    public class ReclamoController : Controller
    {

        public ActionResult ListarReclamos()
        {
            BLReclamoController BLreclamo = new BLReclamoController();
            List<DtoReclamo> colReclamos = BLreclamo.reclamosCronologicamente();
            return View(colReclamos);
        }
        public ActionResult Agregar()
        {
            return View();
        }

        public ActionResult AgregarReclamo(DtoReclamo dtoReclamo)
        {
            BLReclamoController BLreclamo = new BLReclamoController();
            BLreclamo.agregarReclamo(dtoReclamo);
            return RedirectToAction("ListarReclamos");
        }
    }
}