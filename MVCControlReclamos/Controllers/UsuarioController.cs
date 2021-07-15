using BusinessLogic.Controllers;
using Common.DTOs;
using MVCControlReclamos.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCControlReclamos.Controllers
{
    [UserAuthentication]
    public class UsuarioController : Controller
    {
       
        public ActionResult AgregarUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarUsuario(DtoUsuario dtoUsuario)
        {
            BLUsuarioController BLUsuario = new BLUsuarioController();
            BLUsuario.altaUsuario(dtoUsuario);
            return RedirectToAction("AgregarUsuario");
        }

       /* public ActionResult ListarUsuarios()
        {
            BLUsuarioController BLUsuario = new BLUsuarioController();
            List<DtoUsuario> colUsuarios = BLUsuario.l();
            return View(colUsuarios);
        }*/


        // /Usuario/AgregarUsuario

    }
}
