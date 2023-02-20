using ApplicationCore.Services;
using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Condominium.Controllers
{
    public class RubrosCobrosController : Controller
    {
        // GET: RubrosCobros
        public ActionResult Index()
        {
            IEnumerable<RUBRO_COBRO> list = null;
            try
            {
                {
                    IServiceRubrosCobros _ServiceRubrosCobros = new ServiceRubrosCobros();
                    list = _ServiceRubrosCobros.GetRubrosCobros();
                    return View(list);
                }
            }
            catch
            {
                throw;
            }
            return View();
        
        }
    }
}