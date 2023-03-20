using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Filters;
using System.Web.Mvc;
using System.Web.Routing;

namespace Condominium.Security
{
    public class CustomAuthenticationFilter : ActionFilterAttribute, IAuthenticationFilter
    {
        //Método para autenticar la solicitud
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if ((USUARIO)filterContext.HttpContext.Session["User"] == null)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                // Redirija al Controller Login
                filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                {
                 { "controller", "Login" },
                 { "action", "Index" }
                 });
            }
        }
    }
}