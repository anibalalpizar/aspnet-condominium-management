using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Condominium.Security
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        //Roles permitidos
        private readonly int[] allowedroles;
        public CustomAuthorizeAttribute(params int[] roles)
        {
            //roles Obtiene los roles de usuario autorizados
            //para acceder al controlador o al método de acción.
            this.allowedroles = roles;
        }
        //Verificaciones de autorización personalizadas
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
            var oUsuario = (USUARIO)httpContext.Session["User"];
            if (oUsuario != null)
            {
                foreach (var rol in allowedroles)
                {
                    if (rol == oUsuario.IdRol)
                        return true;
                }
            }
            return authorize;
        }
        //Procesa solicitudes HTTP que fallan en la autorización.
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            // Si hubo un error redireccione a el siguiente Controller y View
            filterContext.Result = new RedirectToRouteResult(
            new RouteValueDictionary
            {
             { "controller", "Login" },
            { "action", "UnAuthorized" }
                        });
        }
    }
}