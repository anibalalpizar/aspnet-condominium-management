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
                IEnumerable<RESIDENCIA> lista = null;
                IServiceResidencia residencia = new ServiceResidencia();
                lista= residencia.GetResidencia();
                return View(lista);
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
            ServiceResidencia _serviceResidencia = new ServiceResidencia();
            RESIDENCIA residencia = null;
            try
            {
                // si va null
                if (id == null)
                {
                    return RedirectToAction("Index");
                }
                residencia = _serviceResidencia.GetResidenciaById(Convert.ToInt32(id));
                if (residencia == null)
                {
                    TempData["Message"] = "No se encontro el registro";
                    TempData["Redirect"] = "Residencia";
                    TempData["Redirect-Action"] = "Index";
                    return RedirectToAction("Default", "Error");
                }
                return View(residencia);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos!" + ex.Message;
                return RedirectToAction("Default", "Error");
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.listaResidente = listResidente();
            ViewBag.listaEstado= listEstado();
            return View();
        }

        private SelectList listResidente(int id = 0)
        {
            IServiceUsuario serviceUsuario = new ServiceUsuario();
            IEnumerable<USUARIO> lista = serviceUsuario.GetUSUARIOs();
            return new SelectList(lista, "ID_USUARIO", "NOMBRE", id);
        }

        private SelectList listEstado(int id = 0)
        {
            IServiceEstadoResidencia serviceEstadoResidencia = new ServiceEstadoResidencia();
            IEnumerable<ESTADO_RESIDENCIA> lista = serviceEstadoResidencia.GetEstadoResidencia();
            return new SelectList(lista, "ID_ESTADO_RESIDENCIA", "ESTADO_RESIDENCIA1", id);
        }

        [HttpPost]
        public ActionResult Save(RESIDENCIA rESIDENCIA)
        {
            try
            {
                IServiceResidencia serviceResidencia = new ServiceResidencia();

                if (ModelState.IsValid)
                {
                    RESIDENCIA oResidencia= serviceResidencia.Save(rESIDENCIA);
                }
                else
                {
                    ViewBag.listaResidente= listResidente((int)rESIDENCIA.ID_USUARIO);
                    ViewBag.listaEstado = listEstado(rESIDENCIA.ID_ESTADO_RESIDENCIA);

                    if (rESIDENCIA.ID_RESIDENCIA > 0)
                    {
                        return (ActionResult)View("Edit", rESIDENCIA);
                    }
                    else
                    {
                        return View("Create", rESIDENCIA);
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

        public ActionResult Edit(int? id)
        {
            IServiceResidencia serviceResidencia = new ServiceResidencia();
            RESIDENCIA residencia = null;
            try
            {
                if (id == null)
                {
                    return RedirectToAction("IndexAdmin");
                }

                residencia = serviceResidencia.GetResidenciaById(Convert.ToInt32(id));

                if (residencia == null)
                {
                    TempData["Message"] = "No existe la incidencia solicitado";
                    TempData["Redirect"] = "RubrosCobros";
                    TempData["Redirect-Action"] = "IndexAdmin";
                    return RedirectToAction("Default", "Error");
                }
                ViewBag.ID_USUARIO = listResidente((int)residencia.ID_USUARIO);
                ViewBag.ID_ESTADO_RESIDENCIA = listEstado(residencia.ID_ESTADO_RESIDENCIA);

                return View(residencia);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos!" + ex.Message;
                return RedirectToAction("Default", "Error");
            }
        }

        public ActionResult EditEstado(int? id)
        {
            IServiceResidencia serviceResidencia = new ServiceResidencia();
            RESIDENCIA residencia = null;
            try
            {
                if (id == null)
                {
                    return RedirectToAction("IndexAdmin");
                }

                residencia = serviceResidencia.GetResidenciaById(Convert.ToInt32(id));

                if (residencia == null)
                {
                    TempData["Message"] = "No existe la incidencia solicitado";
                    TempData["Redirect"] = "RubrosCobros";
                    TempData["Redirect-Action"] = "IndexAdmin";
                    return RedirectToAction("Default", "Error");
                }
                ViewBag.ID_USUARIO = listResidente((int)residencia.ID_USUARIO);
                ViewBag.ID_ESTADO_RESIDENCIA = listEstado(residencia.ID_ESTADO_RESIDENCIA);

                return View(residencia);
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