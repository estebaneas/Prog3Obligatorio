using System;
using Common.DTOs;
using BusinessLogic.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCliente.Controllers
{
    public class ReclamoController : Controller
    {
        // GET: Reclamo

        public ActionResult Agregar()
        {
            BLTipoDeReclamoController BLTipoReclamo = new BLTipoDeReclamoController();
            List<SelectListItem> colTiposReclamos = new List<SelectListItem>();
            List<DtoTipoReclamo> colDtoTipos = BLTipoReclamo.getTiposDeReclamos();

            foreach (DtoTipoReclamo item in colDtoTipos)
            {
                SelectListItem option = new SelectListItem();
                option.Value = item.numero.ToString();
                option.Text = item.nombre;
                colTiposReclamos.Add(option);
            }
            ViewBag.listaDeTipos = colTiposReclamos;
            return View();
        }


        public JsonResult validarPunto(double latitud, double longitud)
        {
            BLZonaController BLZ = new BLZonaController();
            DtoPunto punto = new DtoPunto();
            punto.latitud = latitud;
            punto.longitud = longitud;
            List<DtoZona> colZonas = BLZ.listarZonas();
            int numZona = BLZ.puntoEnZonas(punto, colZonas);
            bool enZona = true;
            if(numZona==-1)
            {
                enZona = false;
            }
            return Json(enZona, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AgregarReclamo(DtoReclamo dtoReclamo)
        {
            BLReclamoController BLreclamo = new BLReclamoController();
            BLZonaController BLZ = new BLZonaController();
            BLCuadrillaController BLC = new BLCuadrillaController();
            DtoPunto punto = new DtoPunto();
            List<DtoZona> colZonas = BLZ.listarZonas();
            punto.latitud = dtoReclamo.latitud;
            punto.longitud = dtoReclamo.longitud;
            int numZona= BLZ.puntoEnZonas(punto, colZonas);
            DtoZona zona = colZonas.FirstOrDefault(z=>z.numero==numZona);
            List<DtoCuadrilla> colCuadrillas = BLC.getCuadrillasPorZona(numZona);
            List<DtoReclamo> reclamosActivos = BLreclamo.reclamosSinTerminar().Where(r => r.estado == estadoReclamo.EN_PROCESO&&r.estado==estadoReclamo.ASIGNADO).ToList();
            DtoCuadrilla cuadrillConMenosReclamos = colCuadrillas.OrderByDescending(c => c.colDtoReclamo.Count()).LastOrDefault();
            dtoReclamo.numeroCuadrilla = cuadrillConMenosReclamos.numero;
            dtoReclamo.numeroZona = numZona;
            dtoReclamo.fechaIngreso = DateTime.Now;
            dtoReclamo.emailUsuario = "test";
            dtoReclamo.estado = estadoReclamo.ASIGNADO;
            BLreclamo.agregarReclamo(dtoReclamo);
            return RedirectToAction("ListarReclamos");
        }

        public ActionResult AgregarR()
        {
            return View();
        }
        public ActionResult ListarReclamos()
        {
            BLReclamoController BLreclamo = new BLReclamoController();
            List<DtoReclamo> colReclamos = BLreclamo.reclamosCronologicamente();
            return View(colReclamos);
        }

     
    }
}
