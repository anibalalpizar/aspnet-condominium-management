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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<NOTICIA> list = null;
            try
            {
                IServiceNoticias _ServiceNoticias = new ServiceNoticias();
                list = _ServiceNoticias.GetNoticias();
                return View(list);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos!" + ex.Message;
                return RedirectToAction("Default", "Error");
            }
        }

        public ActionResult DownloadDocumento(int id)
        {
            using (var db = new MyContext())
            {
                var noticia = db.NOTICIA.Find(id);
                if (noticia == null || noticia.DOCUMENTO == null)
                {
                    return HttpNotFound();
                }

                var fileName = "documento.pdf";
                return File(noticia.DOCUMENTO, "application/pdf", fileName);
            }
        }
    }

}