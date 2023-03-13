using ApplicationCore.Services;
using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using static System.Collections.Specialized.BitVector32;

namespace Condominium.Controllers
{
    public class IncidenciaController : Controller
    {
        // GET: Incidencia
        public ActionResult Index()
        {
            IEnumerable<INCIDENCIA> list = null;
            try
            {
                IServiceIncidencia serviceIncidencia = new ServiceIncidencia();
                list= serviceIncidencia.GetIncidencias();
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
            IEnumerable<INCIDENCIA> list = null;
            try
            {
                IServiceIncidencia serviceIncidencia = new ServiceIncidencia();
                list = serviceIncidencia.GetIncidencias();
                return View(list);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos!" + ex.Message;
                return RedirectToAction("Default", "Error");
            }
        }

        //Vista Crear una nueva incidencia
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.idResidente = listResidente();
            ViewBag.idEstadoIncidencia = listEstadoIncidencia();
            return View();
        }

        private SelectList listResidente(int idUsuario = 0)
        {
            IServiceUsuario serviceUsuario = new ServiceUsuario();
            IEnumerable<USUARIO> listaResidencia = serviceUsuario.GetUSUARIOs();
            return new SelectList(listaResidencia, "ID_USUARIO", "NOMBRE", idUsuario);
        }
        
        public SelectList listEstadoIncidencia(int idEstadoIncidencia = 0)
        {
            IServiceEstadoIncidencia serviceEstadoIncidencia = new ServiceEstadoIncidencia();
            IEnumerable<ESTADO_INCIDENCIA> listaEstado = serviceEstadoIncidencia.getEstadoDeuda();
            return new SelectList(listaEstado, "ID_ESTADO_INCIDENCIA", "ESTADO_INCIDENCIA", idEstadoIncidencia);
        }
        //Guardar Incidencia
        [HttpPost]
        public ActionResult Save(INCIDENCIA incidencia)
        {
            IServiceIncidencia serviceIncidencia = new ServiceIncidencia();

            try
            {
                if (ModelState.IsValid) 
                {
                    INCIDENCIA inci = serviceIncidencia.Save(incidencia);
                }
                else
                {
                    ViewBag.idResidente = listResidente(incidencia.ID_USUARIO);
                    ViewBag.idEstadoIncidencia = listEstadoIncidencia(incidencia.ID_ESTADO_INCIDENCIA);
                    
                    if(incidencia.ID_INCIDENCIA > 0)
                    {
                        return (ActionResult)View("Edit", incidencia);
                    }
                    else
                    {
                        return View("Create", incidencia);
                    }
                }

                return RedirectToAction("IndexAdmin");
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos!" + ex.Message;
                return RedirectToAction("Default", "Error");
            }
        }


        //Vista para editar
        public ActionResult Edit(int? id)
        {
            ServiceIncidencia serviceIncidencia = new ServiceIncidencia();
            INCIDENCIA incidencia = null;
            try
            {
                if(id == null)
                {
                    return RedirectToAction("IndexAdmin");
                }

                incidencia = serviceIncidencia.GetIncidenciaById(Convert.ToInt32(id));

                if(incidencia == null)
                {
                    TempData["Message"] = "No existe la incidencia solicitado";
                    TempData["Redirect"] = "RubrosCobros";
                    TempData["Redirect-Action"] = "IndexAdmin";
                    return RedirectToAction("Default", "Error");
                }

                ViewBag.ID_USUARIO = listResidente(incidencia.ID_USUARIO);
                ViewBag.ID_ESTADO_INCIDENCIA = listEstadoIncidencia(incidencia.ID_ESTADO_INCIDENCIA);

                return View(incidencia);
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