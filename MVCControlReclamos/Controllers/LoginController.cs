using BusinessLogic.Controllers;
using Common.Constantes;
using Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCControlReclamos.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                return Redirect("/Home");
            }

            return View();
        }

        public ActionResult LogOut()
        {
            //SignOut() Limpia la Cookie de Autenticación
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult Login(DtoLogin dto)
        {
            BLUsuarioController BLUsuario = new BLUsuarioController();
            //Ir a validar con la base de datos
            if (BLUsuario.VerificarUsuarioPassword(dto.username, dto.password) && BLUsuario.EsFuncionario(dto.username))
            {
                //Crea la Cookie para que el usuario sea autenticado
                FormsAuthentication.SetAuthCookie(dto.username, false);

                Session[CLogin.KEY_SESSION_USERNAME] = dto.username;
                Session[CLogin.KEY_SESSION_TIPO_USER] = "1";

                return Redirect("/Home");
            }

            return View();
        }
    }
}