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
    public class GestionPlanesCobroController : Controller
    {
        // GET: GestionPlanesCobro
        public ActionResult Index()
        {
            IEnumerable<GESTION_PLANES_COBRO> list = null;
            try
            {
                IServiceGestionPlanesCobro serviceGestionPlanesCobro =  new ServiceGestionPlanesCobro();
                list = serviceGestionPlanesCobro.getGestionPlanesCobro();
                return View(list);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos!" + ex.Message;
                return RedirectToAction("Default", "Error");
            }
        }

        public ActionResult IndexDeudasVigentes()
        {
            IEnumerable<GESTION_PLANES_COBRO> list = null;
            try
            {
                IServiceGestionPlanesCobro serviceGestionPlanesCobro = new ServiceGestionPlanesCobro();
                list = serviceGestionPlanesCobro.getGestionPlanesCobroVigentes();
                return View(list);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos!" + ex.Message;
                return RedirectToAction("Default", "Error");
            }
        }

        public ActionResult IndexHistorialPagos()
        {
            IEnumerable<GESTION_PLANES_COBRO> list = null;
            try
            {
                IServiceGestionPlanesCobro serviceGestionPlanesCobro = new ServiceGestionPlanesCobro();
                list = serviceGestionPlanesCobro.getGestionPlanesCobro();
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
            try
            {
                IEnumerable<GESTION_PLANES_COBRO> lista = null;
                IServiceGestionPlanesCobro serviceGestionPlanesCobro =  new ServiceGestionPlanesCobro();
                lista = serviceGestionPlanesCobro.getGestionPlanesCobro();
                return View(lista);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                return RedirectToAction("Default", "Error");
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.idResidencia = listaResidencias();
         //   ViewBag.idEstadoDeuda = listaEstadoDeuda();
            ViewBag.idPlanCobro= listaPlanCobro();
            return View();
        }

        private SelectList listaResidencias(int id = 0)
        {
            IServiceResidencia serviceResidencia = new ServiceResidencia();
            IEnumerable<RESIDENCIA> lista = serviceResidencia.GetResidencia();
            return new SelectList(lista, "ID_RESIDENCIA", "NUMERO_RESIDENCIA", id);
        }

        private SelectList listaEstadoDeuda(int id =0)
        {
            IServiceEstadoDeuda service = new ServiceEstadoDeuda();
            IEnumerable<ESTADO_DEUDA> lista = service.getEstadoDeuda();
            return new SelectList(lista, "ID_ESTADO_DEUDA", "NOMBRE_ESTADO_DEUDA", id);
        }

        private SelectList listaPlanCobro(int id = 0)
        {
            IServicePlanCobro servicePlanCobro = new ServicePlanCobro();
            IEnumerable<PLAN_COBRO> lista = servicePlanCobro.GetPlanCobro();
            return new SelectList(lista, "ID_COBRO_PLAN", "NOMBRE", id);
        }


        [HttpPost]
        public ActionResult Save( GESTION_PLANES_COBRO gestion)
        {
            try
            {
                IServiceGestionPlanesCobro serviceGestionPlanes = new ServiceGestionPlanesCobro();

                if (ModelState.IsValid) 
                {
                    GESTION_PLANES_COBRO oGestion = serviceGestionPlanes.Save(gestion);
                }
                else
                {
                    ViewBag.idResidencia = listaResidencias(gestion.ID_RESIDENCIA);
                  //  ViewBag.idEstadoDeuda = listaEstadoDeuda(gestion.ID_ESTADO_DEUDA);
                    ViewBag.idPlanCobro = listaPlanCobro((int)gestion.ID_PLAN_COBRO);

                    if (gestion.ID_GESTION_PLANES_COBRO > 0)
                    {
                        return (ActionResult)View("Edit", gestion);
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

        public ActionResult Edit(int? id)
        {
            try
            {
                IServiceGestionPlanesCobro serviceGestionPlanes = new ServiceGestionPlanesCobro();
                GESTION_PLANES_COBRO oGestion = null;

                if (id == null)
                {
                    return RedirectToAction("IndexAdmin");
                }

                oGestion = serviceGestionPlanes.getGestionPlanesCobroById(Convert.ToInt32(id));

                if (oGestion == null)
                {
                    TempData["Message"] = "No existe la noticia solicitado";
                    TempData["Redirect"] = "RubrosCobros";
                    TempData["Redirect-Action"] = "IndexAdmin";
                    return RedirectToAction("Default", "Error");
                }


               // ViewBag.ID_RESIDENCIA = listaResidencias(oGestion.ID_RESIDENCIA);
                ViewBag.ID_ESTADO_DEUDA = listaEstadoDeuda(oGestion.ID_ESTADO_DEUDA);
                ViewBag.ID_PLAN_COBRO = listaPlanCobro((int)oGestion.ID_PLAN_COBRO);
                return View(oGestion);
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
            IServiceGestionPlanesCobro serviceGestionPlanes = new ServiceGestionPlanesCobro();
            GESTION_PLANES_COBRO residencia = null;
            try
            {
                // si va null
                if (id == null)
                {
                    return RedirectToAction("Index");
                }
                residencia = serviceGestionPlanes.getGestionPlanesCobroById(Convert.ToInt32(id));
                if (residencia == null)
                {
                    TempData["Message"] = "No se encontro el registro";
                    TempData["Redirect"] = "Residencia";
                    TempData["Redirect-Action"] = "Index";
                    return RedirectToAction("Default", "Error");
                }
                return View(residencia);
            }
            catch
            {
                throw;
            }
        }

      
    }
}