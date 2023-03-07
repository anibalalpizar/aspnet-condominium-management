using ApplicationCore.Services;
using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Condominium.Controllers
{
    public class NoticiasController : Controller
    {
        // GET: Noticias
        public ActionResult IndexAdmin()
        {
            IEnumerable<NOTICIA> lista = null;
            try
            {
                IServiceNoticias _serviceNoticia = new ServiceNoticias();
                lista = _serviceNoticia.GetNoticias();
                ViewBag.listaTipoNoticias = _serviceNoticia.GetNoticiaTipo();
                return View(lista);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                return RedirectToAction("Default", "Error");
            }
        }
    }
}