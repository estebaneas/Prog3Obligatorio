using BusinessLogic.Controllers;
using Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCliente.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario



        /*public ActionResult puntoEnZona (DtoPunto punto)
         {
             BLZonaController BLZ = new BLZonaController();
             List<DtoZona> colZonas = BLZ.listarZonas();
             bool puntoEnZ = BLZ.puntoEnZonas(punto, colZonas);

             return Json()
         }*/

        public ActionResult AgregarUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarUsuario(DtoUsuario dtoUsuario)
        {
            BLUsuarioController BLUsuario = new BLUsuarioController();
            dtoUsuario.funcionario = false;
            BLUsuario.altaUsuario(dtoUsuario);
            return RedirectToAction("AgregarUsuario");
        }
    }
}