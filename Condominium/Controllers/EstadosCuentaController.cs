using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace Condominium.Controllers
{
    public class EstadosCuentaController : Controller
    {
        // GET: EstadosCuenta
        public ActionResult Index()
        {
            List<GESTION_DEUDA> list = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    //list = ctx.GESTION_DEUDA.Include("RESIDENCIA.USUARIO").ToList();

                    list = ctx.GESTION_DEUDA
                       .Include(g => g.ESTADO_DEUDA) 
                       .Include(g => g.RESIDENCIA.USUARIO)
                       .ToList();

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