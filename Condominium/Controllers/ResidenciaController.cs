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
    public class ResidenciaController : Controller
    {
        // GET: Residencia
        public ActionResult Index()
        {
            IEnumerable<RESIDENCIA> list = null;
            try
            {
                IServiceResidencia _ServiceResidencia = new ServiceResidencia();
                list = _ServiceResidencia.GetResidencia();
                return View(list);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos!" + ex.Message;
                return RedirectToAction("Default", "Error");
            }
        }

        public ActionResult Details(int? id)
        {
            ServiceResidencia _serviceResidencia = new ServiceResidencia();
            RESIDENCIA residencia = null;
            try
            {
                // si va null
                if (id == null)
                {
                    return RedirectToAction("Index");
                }
                residencia = _serviceResidencia.GetResidenciaById(Convert.ToInt32(id));
                if (residencia == null)
                {
                    TempData["Message"] = "No se encontro el registro";
                    TempData["Redirect"] = "Residencia";
                    TempData["Redirect-Action"] = "Index";
                    return RedirectToAction("Default", "Error");
                }
                return View(residencia);
            }
            catch
            {
                throw;
            }
        }
    }

}