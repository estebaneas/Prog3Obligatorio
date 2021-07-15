using Common.Constantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCliente.Helpers
{
    public class UserAuthentication : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            bool result = base.AuthorizeCore(httpContext);

            if (result == false)
            {
                return result;
            }

            string tipoUsuario = (string)httpContext.Session[CLogin.KEY_SESSION_TIPO_USER];
            string nombreUsuario = (string)httpContext.Session[CLogin.KEY_SESSION_USERNAME];

            //Verifico si la url tiene al menos un controller y una acción ese controller 
            if (httpContext.Request.CurrentExecutionFilePath.Split('/').Length > 2)
            {

                string controller = httpContext.Request.CurrentExecutionFilePath.Split('/')[1];
                string action = httpContext.Request.CurrentExecutionFilePath.Split('/')[2];

            }

            return true;
        }
    }
}