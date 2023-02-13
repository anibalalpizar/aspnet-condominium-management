using ApplicationCore.Services;
using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Condominium.Controllers
{
    public class NoticiaController : Controller
    {
        // GET: Noticia
        public ActionResult Index()
        {
            IEnumerable<NOTICIA> lista = null;
            try
            {
                IServiceNoticia _ServiceNoticia = new ServiceNoticia();
                lista = _ServiceNoticia.GetNoticias();
            }
            catch
            {
                throw;
            }
            return View(lista);
        }
    }
}