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
            ViewBag.CantPorPag = 10;
            ViewBag.PagActual = 1;
            ViewBag.BtnTarget = "btnRec";
            ViewBag.Target = "target";
            ViewBag.ColReclamosVar = "null";
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
        public ActionResult mostrarReclamos(DtoFiltroReclamo filtro)
        {
            BLReclamoController BLR = new BLReclamoController();
            List<DtoReclamo> colreclamos = new List<DtoReclamo>();
            DateTime? inicio;
            DateTime? final;
            DateTime? ini;
            DateTime? fin;
            string targetID=filtro.targetID;
            int pagActual=filtro.paginaActual;
            int cantPorPag = filtro.cantPorPag;
            int? numZona;
            int? numCuadrilla;
            string estado;
           
            if (filtro.colReclamos[0]==null)
            {
                ini = filtro.ini;
                fin = filtro.fin;
                numZona = filtro.numZona;
                numCuadrilla = filtro.numCuadrilla;
                estado = filtro.estado;
                
                colreclamos = BLR.getReclamos(numZona, numCuadrilla, estado, ini, fin);
                if (ini != null)
                {
                    inicio = ini;
                }
                else
                {
                    inicio = DateTime.MinValue;
                }
                if (fin != null)
                {
                    final = fin;
                }
                else
                {
                    final = DateTime.Now;
                }

                if (numZona != null)
                {
                    colreclamos = colreclamos.Where(r => r.numeroZona == numZona).ToList();
                }
                if (numCuadrilla != null)
                {
                    colreclamos = colreclamos.Where(r => r.numeroCuadrilla == numCuadrilla).ToList();
                }
                colreclamos = colreclamos.Where(r => r.fechaIngreso >= inicio && r.fechaIngreso <= final).ToList();
            }
            else
            {
                colreclamos = filtro.colReclamos;
            }
            ViewBag.ColReclamosVar = filtro.colRelJavVar;
            ViewBag.BtnTarget = filtro.BtnTarget;   
            ViewBag.ColReclamos = filtro.colReclamos;
            ViewBag.TotReclamos = colreclamos.Count();
            ViewBag.PagActual = pagActual;
            ViewBag.Target = targetID;
            colreclamos = colreclamos.OrderByDescending(r => r.fechaIngreso).Skip(cantPorPag * (pagActual - 1)).Take(cantPorPag).ToList();
            return PartialView("_ListarReclamosPartial", colreclamos);
        }

        /* public  ejecutar(int pagActual, int cantPorPag, int? numZona, int? numCuadrilla, string estado, DateTime? ini, DateTime? fin)
         {
            int = mostrarReclamos(pagActual, cantPorPag,  numZona,  numCuadrilla,  estado,  ini,  fin);
         }*/
    }
}