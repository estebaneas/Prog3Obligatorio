using Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCControlReclamos.Controllers
{
    public class UsuarioController : Controller
    {
       
        public ActionResult AgregarUsuario()
        {
            return View();
        }

        // esta seria la accion que guarda el usuario en la base de datos
        /*[HttpPost] 
        public ActionResult GuardarUsuario(DtoUsuario nuevoUsuarioDto)
        {

            return RedirectToAction();
        }*/


        // /Usuario/AgregarUsuario

    }
}
