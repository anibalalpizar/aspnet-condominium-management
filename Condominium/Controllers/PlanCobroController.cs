using ApplicationCore.Services;
using Infraestructure.Model;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.IO;
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

        public ActionResult IndexPrueba()
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

        //Craer Plan de Cobro
        [HttpGet]

        public ActionResult Create()
        {
            ViewBag.idResidente = listResidente();
            ViewBag.idEstadoDeuda = listEstadoDeuda();
            ViewBag.idRubroCobro = listRubros();
          //  ViewBag.montoTotal = montoTotal();
            return View();
        }

        //public RUBRO_COBRO montoTotal(int  id = 0)
        //{
        //    IServiceRubrosCobros serviceRubrosCobros = new ServiceRubrosCobros();
        //    return serviceRubrosCobros.GetRubroCobrosById(Convert.ToInt32(id));
        //}

        private SelectList listResidente(int idUsuario = 0)
        {
            IServiceUsuario serviceUsuario = new ServiceUsuario();
            IEnumerable<USUARIO> listaResidencia = serviceUsuario.GetUSUARIOs();
            return new SelectList(listaResidencia, "ID_USUARIO", "NOMBRE", idUsuario);
        }

        private SelectList listEstadoDeuda(int idEstado = 0)
        {
            IServiceEstadoDeuda service = new ServiceEstadoDeuda();
            IEnumerable<ESTADO_DEUDA> estado = service.getEstadoDeuda();
            return new SelectList(estado, "ID_ESTADO_DEUDA", "NOMBRE_ESTADO_DEUDA");
        }

        private MultiSelectList listRubros(ICollection<RUBRO_COBRO> rubrosCobros = null)
        {
            IServiceRubrosCobros serviceRubrosCobros = new ServiceRubrosCobros();
            IEnumerable<RUBRO_COBRO> lista = serviceRubrosCobros.GetRubrosCobros();
            int[] listaRubros = null;
            if (rubrosCobros != null)
            {
                listaRubros = rubrosCobros.Select(r => r.ID_RUBRO_COBRO).ToArray();
            }

            return new MultiSelectList(lista, "ID_RUBRO_COBRO", "NOMBRE_RUBRO", listaRubros);
        }


        //Guardar / SAVE 
        [HttpPost]
        public ActionResult Save(GESTION_PLANES_COBRO gestion, string[] selectRubrosCobros) 
        {
           
            IServicePlanCobro servicePlanCobro = new ServicePlanCobro();

            try
            {

                if(ModelState.IsValid)
                {
                    GESTION_PLANES_COBRO oGestion = servicePlanCobro.Save(gestion, selectRubrosCobros);

                }
                else
                {
                    ViewBag.idResidente = listResidente((int)gestion.ID_USUARIO);
                    ViewBag.idEstadoDeuda = listEstadoDeuda((int)gestion.ID_ESTADO_DEUDA);
                    ViewBag.idRubroCobro = listRubros(gestion.RUBRO_COBRO);
                   

                    if (gestion.ID_PLAN_COBRO > 0)
                    {
                        return (ActionResult)View("Edit",gestion);
                    }
                    else
                    {
                        return View("Create", gestion);
                    }
                }
                return RedirectToAction("IndexAdmin");  
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Libro";
                TempData["Redirect-Action"] = "IndexAdmin";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }

        }


        //Editar Gestion de Planes cobro
        public ActionResult Edit(int? id)
        {
            ServicePlanCobro service = new ServicePlanCobro();
            GESTION_PLANES_COBRO gestion = null;

            try
            {
                if (id == null)
                {
                    return RedirectToAction("IndexAdmin");
                }

                gestion = service.GetPlanCobroById(Convert.ToInt32(id));


                if (gestion == null)
                {
                    TempData["Message"] = "No existe la noticia solicitado";
                    TempData["Redirect"] = "RubrosCobros";
                    TempData["Redirect-Action"] = "IndexAdmin";
                    return RedirectToAction("Default", "Error");
                }
                ViewBag.ID_USUARIO = listResidente((int)gestion.ID_USUARIO);
                ViewBag.ID_ESTADO_DEUDA = listEstadoDeuda((int)gestion.ID_ESTADO_DEUDA);
                ViewBag.ID_RUBRO_COBRO = listRubros(gestion.RUBRO_COBRO);
                return View(gestion);
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
