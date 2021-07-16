using BusinessLogic.Controllers;
using Common.DTOs;
using MVCCliente.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCliente.Controllers
{
    [UserAuthentication]
    public class HistorialCambiosController : Controller
    {
        public ActionResult ListarHistorialCambios(int nroReclamo)
        {
            BLHistorialCambiosController controller = new BLHistorialCambiosController();
            List<DtoHistorialCambios> col = controller.ListarCambios(nroReclamo);
            return View(col);
        }
    }
}