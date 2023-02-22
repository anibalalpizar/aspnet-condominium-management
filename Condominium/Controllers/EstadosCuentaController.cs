using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ApplicationCore.Services;

namespace Condominium.Controllers
{
    public class EstadosCuentaController : Controller
    {
        // GET: EstadosCuenta
        public ActionResult Index()
        {
            IEnumerable<GESTION_DEUDA> list = null;
            try
            {
                IServiceEstadosCuenta _ServiceEstadosCuenta = new ServiceEstadosCuenta();
                list = _ServiceEstadosCuenta.GetEstadosCuenta();
                return View(list);
            }
            catch
            {
                throw;
            }
            return View();
        }

        public ActionResult Details(int? id)
        {
            GESTION_DEUDA gestion_deuda = null;
            try
            {
                IServiceEstadosCuenta _ServiceEstadosCuenta = new ServiceEstadosCuenta();
                gestion_deuda = _ServiceEstadosCuenta.GetEstadosCuentaById(Convert.ToInt32(id));
                return View(gestion_deuda);
            }
            catch
            {
                throw;
            }
            return View();
        }

        public ActionResult DeudasVigentes()
        {
            IEnumerable<GESTION_DEUDA> list = null;
            try
            {
                // Deudas vigentes
                IServiceEstadosCuenta _ServiceEstadosCuenta = new ServiceEstadosCuenta();
                list = _ServiceEstadosCuenta.GetDeudasVigentes();
                return View(list);
            }
            catch
            {
                throw;
            }
            return View();
        }      
    }
}
