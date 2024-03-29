﻿using BusinessLogic.Controllers;
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
            dtoUsuario.funcionario = true;
            BLUsuario.altaUsuario(dtoUsuario);
            return RedirectToAction("AgregarUsuario");
        }

        public JsonResult ValidarUsuario(string usario)
        {
            bool rest = true;
            BLUsuarioController usuarioController = new BLUsuarioController();
            if (usuarioController.ExisteNombreUsuario(usario) == true)
            {
                rest = false;
            }
            return Json(rest, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ValidarEmail(string email)
        {
            bool rest = true;
            BLUsuarioController usuarioController = new BLUsuarioController();
            if (usuarioController.ExisteEmail(email) == true)
            {
                rest = false;
            }
            return Json(rest, JsonRequestBehavior.AllowGet);
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
