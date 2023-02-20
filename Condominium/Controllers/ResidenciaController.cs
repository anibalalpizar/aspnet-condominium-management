using ApplicationCore.Services;
using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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
            catch
            {
                throw;
            }
            return View();
        }
    }
}