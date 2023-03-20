using ApplicationCore.Services;
using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web;
using Condominium.Utils;

namespace Condominium.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(USUARIO usuario)
        {
            IServiceUsuario _serviceUsuario = new ServiceUsuario();
            USUARIO oUsuario = null;
            try
            {
                ModelState.Remove("NOMBRE");
                ModelState.Remove("APELLIDOS");
                ModelState.Remove("ID_TIPO_USUARIO");
                if (ModelState.IsValid)
                {
                    oUsuario = _serviceUsuario.GetUsuario(usuario.CORREO, usuario.CONTRASENA);

                    if(oUsuario != null)
                    {
                        Session["User"] = oUsuario;
                        Log.Info($"Accede {oUsuario.CORREO}");
                        TempData["mensaje"] = Util.SweetAlertHelper.Mensaje("Login", "Usuario autenticado", Util.SweetAlertMessageType.success);
                        ViewBag.NotificationMessage = Util.SweetAlertHelper.Mensaje("Login", "Usuario autenticado", Util.SweetAlertMessageType.success);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        Log.Warn($"Intento de inicio {usuario.CORREO}");
                        ViewBag.NotificationMessage = Util.SweetAlertHelper.Mensaje("Login", "Usuario no válido", Util.SweetAlertMessageType.warning);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                return RedirectToAction("Default", "Error");
            }
            return View("Index");
        }

        public ActionResult Logout()
        {
            try
            {
                Session["User"] = null;
                Session.Remove("User");
                return RedirectToAction("Index", "Login");
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                return RedirectToAction("Default", "Error");
            }
        }

        public ActionResult UnAuthorized()
        {
            ViewBag.Message = "No autorizado";
            if (Session["User"] != null)
            {
                USUARIO usuario = Session["User"] as USUARIO;
                Log.Warn($"No autorizado {usuario.CORREO}");
            }
            return View();
        }
    }
}