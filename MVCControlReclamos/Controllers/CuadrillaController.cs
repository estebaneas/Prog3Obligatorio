using BusinessLogic.Controllers;
using Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCControlReclamos.Controllers
{
    public class CuadrillaController : Controller
    {
        public ActionResult ListarCuadrillas()
        {
            BLCuadrillaController BLCuadrilla = new BLCuadrillaController();
            List<DtoCuadrilla> colCuadrillas = BLCuadrilla.getColCuadrilla();

            return View(colCuadrillas);
        }
        
        public ActionResult Agregar()
        {
            return View();
        }

        public ActionResult AgregarCuadrilla(DtoCuadrilla dtoCuadrilla)
        {
            BLCuadrillaController BLCuadrilla = new BLCuadrillaController();
            BLCuadrilla.agregarCuadrilla(dtoCuadrilla);

            return RedirectToAction("ListarCuadrillas");
        }
    }
}