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
    public class AreasComunesController : Controller
    {
        // GET: AreasComunes
        public ActionResult Index()
        {
            IEnumerable<RESERVA_AREA_COMUN> lista = null;
            try
            {
                IServiceAreasComunes _serviceAreaComun = new ServiceAreasComunes();
                lista = _serviceAreaComun.GetAreasComunes();
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