using BusinessLogic.Controllers;
using Common.Constantes;
using Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCCliente.Controllers
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
            if (BLUsuario.VerificarUsuarioPassword(dto.username, dto.password))
            {
                if (!BLUsuario.EsFuncionario(dto.username))
                {
                    //Crea la Cookie para que el usuario sea autenticado
                    FormsAuthentication.SetAuthCookie(dto.username, false);

                    Session[CLogin.KEY_SESSION_USERNAME] = dto.username;
                    Session[CLogin.KEY_SESSION_TIPO_USER] = "2";

                    return Redirect("/Home");
                }
                else
                {
                    ModelState.AddModelError("ErrorGeneral", "Registrado como funcionario. Ingrese al portal de funcionario o registrese en este portal.");
                }
            }
            else
            {
                ModelState.AddModelError("ErrorGeneral", "Usuario o contraseña incorrectos");
            }

            return View();
        }
    }
}