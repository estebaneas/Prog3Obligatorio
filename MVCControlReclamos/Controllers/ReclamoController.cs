﻿using BusinessLogic.Controllers;
using Common.DTOs;
using DataAccess.Model;
using MVCControlReclamos.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVCControlReclamos.Controllers
{
    [UserAuthentication]
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
            BLTipoDeReclamoController BLT = new BLTipoDeReclamoController();
            BLZonaController BLZ = new BLZonaController();
            BLCuadrillaController BLC = new BLCuadrillaController();
            List<SelectListItem> listaTipo = new List<SelectListItem>();
            List<SelectListItem> listaZona = new List<SelectListItem>();
            List<SelectListItem> listaCuadrilla = new List<SelectListItem>();
            List<SelectListItem> listaEstado = new List<SelectListItem>();
            List<DtoTipoReclamo> colTipos = BLT.getTiposDeReclamos();
            List<DtoZona> colZonas = BLZ.listarZonas();
            List<DtoCuadrilla> colCuadrillas = BLC.getColCuadrilla();
            

            foreach(DtoTipoReclamo item in colTipos)
            {
                SelectListItem opcion = new SelectListItem();
                opcion.Value = item.numero.ToString();
                opcion.Text = item.nombre;
                listaTipo.Add(opcion);
            }

            foreach (DtoZona item in colZonas)
            {
                SelectListItem opcion = new SelectListItem();
                opcion.Value = item.numero.ToString();
                opcion.Text = item.nombre;
                listaZona.Add(opcion);
            }

            foreach (DtoCuadrilla item in colCuadrillas)
            {
                SelectListItem opcion = new SelectListItem();
                opcion.Value = item.numero.ToString();
                opcion.Text = item.nombre;
                listaCuadrilla.Add(opcion);
            }
            List<String> test = new List<String>();
            foreach (estadoReclamo estado in Enum.GetValues(typeof(estadoReclamo)))
            {
                SelectListItem opcion = new SelectListItem();
                opcion.Value = estado.ToString();
                opcion.Text = enumATexto(estado);
                listaEstado.Add(opcion);
            }

            ViewBag.ListaTipos = listaTipo;
            ViewBag.ListaZonas = listaZona;
            ViewBag.ListaCuadrillas = listaCuadrilla;
            ViewBag.ListaEstados = listaEstado;

            return View(colReclamos);
        }
   
        public string enumATexto(estadoReclamo estadoEn)
        {
            string estado = estadoEn.ToString();
            string arreglado = "";

            StringBuilder sb = new StringBuilder(estado);
            

            for (int i = 0; i<estado.Length;i++)
            {
                if (i > 0)
                {
                    if (estado[i].Equals('_'))
                    {
                        arreglado += " ";
                    }
                    else if (estado[i - 1].Equals('_') && i > 0)
                    {
                        arreglado += char.ToUpper(estado[i]).ToString();
                    }
                    else
                    {
                        arreglado += char.ToLower(estado[i]).ToString();
                    }
                }
                else
                {
                    arreglado += estado[i].ToString();
                }

            }

            return arreglado;
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

        public ActionResult mostrarReclamos(DtoFiltroReclamo filtro)
        {
            BLReclamoController BLR = new BLReclamoController();
            List<DtoReclamo> colreclamos = new List<DtoReclamo>();
            DateTime? ini;
            DateTime inicio;
            string targetID=filtro.targetID;
            int pagActual=filtro.paginaActual;
            int cantPorPag = filtro.cantPorPag;
            int? numZona;
            int? numCuadrilla;
            string estado;
            int? numTipo = filtro.tipo;
            

            if (filtro.colReclamos[0]==null)
            {

                ini = filtro.ini;
                if(ini!=null)
                {
                    inicio = (DateTime)ini;
                }
                else
                {
                    inicio = DateTime.MinValue;
                }

                numZona = filtro.numZona;
                numCuadrilla = filtro.numCuadrilla;
                estado = filtro.estado;
                ViewBag.ColReclamosVar = "null";

                colreclamos = BLR.getReclamos(numZona, numCuadrilla, estado, ini);
                
                if (ini != null)
                {
                    colreclamos =colreclamos.Where(r=>r.fechaIngreso.Date==inicio).ToList();
                }
                if (numTipo != null)
                {
                    colreclamos = colreclamos.Where(r => r.numTipoReclamo == numTipo).ToList();
                }
                if (numZona != null)
                {
                    colreclamos = colreclamos.Where(r => r.numeroZona == numZona).ToList();
                }
                if (estado != null)
                {
                    colreclamos = colreclamos.Where(r => r.estado.ToString()==estado).ToList();
                }


            }
            else
            {
                colreclamos = filtro.colReclamos;
                ViewBag.ColReclamosVar = filtro.colRelJavVar;
            }
            ViewBag.CantPorPag = filtro.cantPorPag;
            ViewBag.BtnTarget = filtro.BtnTarget;   
            ViewBag.ColReclamos = filtro.colReclamos;
            ViewBag.TotReclamos = colreclamos.Count();
            ViewBag.PagActual = pagActual;
            ViewBag.Target = targetID;
            colreclamos = colreclamos.OrderByDescending(r => r.fechaIngreso).Skip(cantPorPag * (pagActual - 1)).Take(cantPorPag).ToList();
            return PartialView("_ListarReclamosPartial", colreclamos);
        }

    }
}