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
    public class UsuarioController : Controller
    {
        public ActionResult AgregarUsuario()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                return Redirect("/Home");
            }

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

        public JsonResult ValidarCodigo(string nomUsuario)
        {
            bool rest = true;
            BLUsuarioController usuarioController = new BLUsuarioController();
            if (usuarioController.ExisteNombreUsuario(nomUsuario) == true)
            {
                rest = false;
            }
            return Json(rest, JsonRequestBehavior.AllowGet);
        }
    }
}