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
    public class PlanCobroController : Controller
    {
        // GET: PlanCobro
        public ActionResult Index()
        {
            IEnumerable<GESTION_PLANES_COBRO> list = null;
            try
            {
                IServicePlanCobro _ServicePlanCobro = new ServicePlanCobro();
                list = _ServicePlanCobro.GetPlanCobro();
                return View(list);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos!" + ex.Message;
                return RedirectToAction("Default", "Error");
            }
        }

        public ActionResult IndexAdmin()
        {
            IEnumerable<GESTION_PLANES_COBRO> list = null;
            try
            {
                IServicePlanCobro _ServicePlanCobro = new ServicePlanCobro();
                list = _ServicePlanCobro.GetPlanCobro();
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
            IServicePlanCobro _serviceResidencia = new ServicePlanCobro();
            GESTION_PLANES_COBRO planCobro = null;
            try
            {
                if (id == null)
                {
                    return RedirectToAction("Index");
                }
                planCobro = _serviceResidencia.GetPlanCobroById(Convert.ToInt32(id));
                if (planCobro == null)
                {
                    TempData["Message"] = "No se encontro el registro";
                    TempData["Redirect"] = "PlanCobro";
                    TempData["Redirect-Action"] = "Index";
                    return RedirectToAction("Default", "Error");
                }
                return View(planCobro);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos!" + ex.Message;
                return RedirectToAction("Default", "Error");
            }
        }

    }
}
