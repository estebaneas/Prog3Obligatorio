using System;
using BusinessLogic.Controllers;
using Common.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace MVCControlReclamos.Controllers
{
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
            return RedirectToAction("Zonas");
        }
        public ActionResult Preuba()
        {
            return View();
        }
    }
}