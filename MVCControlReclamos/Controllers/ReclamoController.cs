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

        [HttpPost]
        public ActionResult AgregarReclamo(DtoReclamo dtoReclamo)
        {


            BLReclamoController BLreclamo = new BLReclamoController();
            dtoReclamo.fechaIngreso = DateTime.Now;
            BLreclamo.agregarReclamo(dtoReclamo);
            return RedirectToAction("ListarReclamos");
        }

        [HttpPost]
        
        public ActionResult EditarReclamo (DtoReclamo dto)
        {
            BLReclamoController reclamoController = new BLReclamoController();
            List<string> colErrores = reclamoController.modificarReclamo(dto);
           

            foreach (string error in colErrores)
            {
                ModelState.AddModelError("ErrorGeneral", error);
            }

           
            return RedirectToAction("ListarReclamos");

        }

        public ActionResult IrEditar(int nroReclamo)
        {
            BLReclamoController reclamoController = new BLReclamoController();
            DtoReclamo reclamo = reclamoController.GetById(nroReclamo);


            List<SelectListItem> colEstadoReclamos = new List<SelectListItem>();
            List<string> colEstados = new List<string>() {"EN PROCESO", "RESUELTO", "DESESTIMADO" };

            for (int i = 0; i < colEstados.Count; i++)
            {
                SelectListItem option = new SelectListItem();
                option.Value = colEstados[i];
                option.Text = colEstados[i];
                colEstadoReclamos.Add(option);
            }
            ViewBag.listaDeEstados = colEstadoReclamos;
            return View("EditarReclamo",reclamo);
        }


        
    }
}