using ApplicationCore.Services;
using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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
            catch
            {
                throw;
            }
        }

    }
}
