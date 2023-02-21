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
            GESTION_DEUDA oGestionDeuda = null;
            using (CONDOMINIOSEntities ctx = new CONDOMINIOSEntities())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                oGestionDeuda = ctx.GESTION_DEUDA.
                    Where(l => l.ID_GESTION_DEUDA == id).
                    Include(x => x.RESIDENCIA).
                    Include(y => y.RESIDENCIA.USUARIO).
                    Include(z => z.RESIDENCIA.ESTADO_RESIDENCIA).
                    FirstOrDefault();
            }
            return View(oGestionDeuda);
        }
    }
}