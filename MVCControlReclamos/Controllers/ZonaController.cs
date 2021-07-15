using System;
using BusinessLogic.Controllers;
using Common.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using MVCControlReclamos.Helpers;

namespace MVCControlReclamos.Controllers
{
    [UserAuthentication]
    public class ZonaController : Controller
    {
        // GET: Zona
        public ActionResult Zonas()
        {
            BLZonaController BLZ = new BLZonaController();
            List<DtoZona> colZonas = BLZ.listarZonas();
            ViewBag.ColZonas = colZonas;
            return View(colZonas);
        }

         public ActionResult NuevaZona()
        {
            BLZonaController BLZ = new BLZonaController();
            List<DtoZona> colZonas = BLZ.listarZonas();
            ViewBag.ColZonas = colZonas;
            ViewBag.NumeroZona = colZonas.LastOrDefault().numero+1;
            return View();
        }

         public ActionResult puntoEnZonaPrueba()
        {
            BLZonaController BLZ = new BLZonaController();
            List<DtoZona> colZonas = BLZ.listarZonas();
            DtoPunto punto = new DtoPunto(39.85296477829779, -4.040275768768988); 
            int esta=BLZ.puntoEnZonas(punto,colZonas);
            ViewBag.Esta = esta; 
            return View();
        }

        
        [HttpPost]
        public ActionResult AgregarZona(DtoZona nDtoZona)
        {
            BLZonaController BLZ = new BLZonaController();
            var resultado = new JsonResult
            {
                Data = JsonConvert.DeserializeObject(nDtoZona.Puntos)
            };
            string jsonString = JsonConvert.SerializeObject(resultado);
            JObject colPuntos = JObject.Parse(jsonString);
            List<DtoPunto> puntos = colPuntos["Data"].ToObject<List<DtoPunto>>();
            int numero = 0;
            foreach(DtoPunto item in puntos)
            {
                item.numero=numero++;
                item.numeroZona = nDtoZona.numero;
            }
            nDtoZona.colDtoPunto = puntos;
            BLZ.agregarZona(nDtoZona);
            return View("NuevaZona");

        }



        public JsonResult ValidarPoligono(string puntos)
        {
            BLZonaController BLZ = new BLZonaController();
            var resultado = new JsonResult()
            {
                Data = JsonConvert.DeserializeObject(puntos)
            };
            List<DtoZona> colZonas =  BLZ.listarZonas();
            string jsonString = JsonConvert.SerializeObject(resultado);
            JObject colPuntos = JObject.Parse(jsonString);
            List<DtoPunto> poligono = colPuntos["Data"].ToObject<List<DtoPunto>>();
            bool pEnZona = false;
            bool superPuesto = false;
            bool vacio = false;
            if (!(poligono.Count()==0)) { 
                foreach(DtoZona zona in colZonas)
                {
                    foreach(DtoPunto punto in zona.colDtoPunto)
                    {
                        if (BLZ.puntoEnZona((double)punto.longitud, (double)punto.latitud, poligono))
                        {
                            pEnZona = true;
                        }
                    }
                }
                superPuesto = BLZ.zonaSuperPuesta(poligono, colZonas);
            }
            else
            {
                vacio = true;
            }


            if (poligono.Count()<3||vacio)
            {
                return Json("• La zona requiere de al menos 3 puntos", JsonRequestBehavior.AllowGet);
            }
            else if(pEnZona||superPuesto)
            {
                return Json("• La zona no puede superponerse a otra", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpGet]
        public ActionResult cargarZonasBD()
        {
            BLZonaController BLZ = new BLZonaController();
            List<DtoZona> colZonas = BLZ.listarZonas();
            ViewBag.ColZonas = colZonas;
            return Json(colZonas,JsonRequestBehavior.AllowGet);

        }


        public ActionResult Preuba()
        {
            return View();
        }
    }
}