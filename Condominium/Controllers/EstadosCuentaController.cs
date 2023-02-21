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
    }
}