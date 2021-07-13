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

        public ActionResult AsignarZona(int numero)
        {
            BLCuadrillaController BLC = new BLCuadrillaController();
            DtoAsignarZonaCuadrilla asignado = new DtoAsignarZonaCuadrilla();
            DtoCuadrilla cuadrilla = BLC.getCuadrilla(numero);
            asignado.numCuadrilla = cuadrilla.numero;
            asignado.nombreCuadrilla = cuadrilla.nombre;
            return View(asignado);
        }

        public ActionResult Asignar(DtoAsignarZonaCuadrilla asignacion)
        {
            BLCuadrillaController BLC = new BLCuadrillaController();
            BLC.asignarCuadrillaZona(asignacion);

            return RedirectToAction("ListarCuadrillas");
        }


        public ActionResult DetalleCuadrilla(int numCuadrilla)
        {
            BLCuadrillaController BLC = new BLCuadrillaController();
            DtoCuadrilla cuadilla = BLC.getCuadrilla(numCuadrilla);
            ViewBag.CantPorPag = 10;
            ViewBag.PagActual = 1;

            return View(cuadilla);
        }


    }
}