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
            List<GESTION_DEUDA> list = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;

                    list = ctx.GESTION_DEUDA
                        .Include(g => g.ESTADO_DEUDA)
                        .Include(g => g.RESIDENCIA.USUARIO)
                        .Where(g => g.ESTADO_DEUDA.NOMBRE_ESTADO_DEUDA == "PENDIENTE")
                        .ToList();

                    if (list.Count > 0)
                    {
                        var mes = list[0].MES.ToString("MMMM");
                        var planCobro = ctx.PLAN_COBRO.Find(list[0].RESIDENCIA.ID_PLAN_COBRO);
                        var totalPagar = planCobro.RUBRO_COBRO.Sum(r => r.MONTO);
                    }
                }
            }
            catch
            {
                throw;
            }
            return View(list);
        }
    }
}