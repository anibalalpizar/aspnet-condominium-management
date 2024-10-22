﻿using ApplicationCore.Services;
using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;

namespace Condominium.Controllers
{
    public class ReservacionAreasComunesController : Controller
    {
        // GET: AreasComunes
        public ActionResult Index()
        {
            IEnumerable<RESERVA_AREA_COMUN> lista = null;
            try
            {
                IServiceReservacionAreasComunes _serviceAreaComun = new ServiceReservacionAreasComunes();
                lista = _serviceAreaComun.GetAreasComunes();
                return View(lista);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                return RedirectToAction("Default", "Error");
            }
        }

        //Vista de los administradores
        public ActionResult IndexAdmin()
        {
            try
            {
                IEnumerable<RESERVA_AREA_COMUN> lista = null;
                IServiceReservacionAreasComunes serviceAreasComunes = new ServiceReservacionAreasComunes();
                lista = serviceAreasComunes.GetAreasComunes();
                return View(lista);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                return RedirectToAction("Default", "Error");
            }
        }

        public ActionResult IndexReservar()
        {
            try
            {
                IEnumerable<RESERVA_AREA_COMUN> lista = null;
                IServiceReservacionAreasComunes serviceAreasComunes = new ServiceReservacionAreasComunes();
                lista = serviceAreasComunes.GetAreasComunes();
                return View(lista);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                return RedirectToAction("Default", "Error");
            }
        }
        //Vista para crear Reservas
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.idResidente = listResidente();
            ViewBag.idAreaComun = ListAreasComunes();
            //  ViewBag.idEstadoReservacion = ListEstadoReservacion();

            return View();
        }

        //Lista para traer los usuarios
        private SelectList listResidente(int idUsuario = 0)
        {
            IServiceUsuario serviceUsuario = new ServiceUsuario();
            IEnumerable<USUARIO> listaResidencia = serviceUsuario.GetUSUARIOs();
            return new SelectList(listaResidencia, "ID_USUARIO", "NOMBRE", idUsuario);
        }

        //Lista para traer las Áreas comunes
        private SelectList ListAreasComunes(int area = 0)
        {
            IServiceAreasComunes services = new ServiceAreasComunes();
            IEnumerable<AREA_COMUN> listaArea = services.GetAreaComun();
            return new SelectList(listaArea, "ID_AREA_COMUN", "AREA_COMUN1", area);
        }

        //Lista para traer los estados de las reservacion
        private SelectList ListEstadoReservacion(int id = 0)
        {
            IServiceEstadoReservacion services = new ServiceEstadoReservacion();
            IEnumerable<ESTADO_RESERVACION> listaEstados = services.GetEstadoReservacion();
            return new SelectList(listaEstados, "ID_ESTADO_RESERVACION", "ESTADO_RESERVACION1", id);
        }

        //Lógica para guardar las reservas o modificarlas
        [HttpPost]
        public ActionResult Save(RESERVA_AREA_COMUN area)
        {
            try
            {
                IServiceReservacionAreasComunes serviceReservacionAreasComunes = new ServiceReservacionAreasComunes();

                if (ModelState.IsValid)
                {
                    RESERVA_AREA_COMUN gArea = serviceReservacionAreasComunes.Save(area);

                }
                else
                {
                    ViewBag.idResidente = listResidente(area.ID_USUARIO);
                    ViewBag.idAreaComun = ListAreasComunes(area.ID_AREA_COMUN);
                    // ViewBag.idEstadoReservacion = ListEstadoReservacion(area.ID_ESTADO_RESERVACION);

                    if (area.ID_RESERVA_AREA_COMUN > 0)
                    {
                        return (ActionResult)View("Edit", area);
                    }
                    else
                    {
                        return View("Create", area);
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

        //Vista para editar las reservas
        public ActionResult Edit(int? id)
        {
            try
            {
                ServiceReservacionAreasComunes serviceReservacionAreasComunes = new ServiceReservacionAreasComunes();
                RESERVA_AREA_COMUN gArea = null;

                if (id == null)
                {
                    return RedirectToAction("IndexAdmin");
                }

                gArea = serviceReservacionAreasComunes.GetReservaById(Convert.ToInt32(id));

                if (gArea == null)
                {

                    TempData["Message"] = "No existe la incidencia solicitado";
                    TempData["Redirect"] = "RubrosCobros";
                    TempData["Redirect-Action"] = "IndexAdmin";
                    return RedirectToAction("Default", "Error");
                }

                ViewBag.ID_USUARIO = listResidente(gArea.ID_USUARIO);
                ViewBag.ID_AREA_COMUN = ListAreasComunes(gArea.ID_AREA_COMUN);
                ViewBag.ID_ESTADO_RESERVCACION = ListEstadoReservacion(gArea.ID_ESTADO_RESERVACION);

                return View(gArea);

            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos!" + ex.Message;
                return RedirectToAction("Default", "Error");
            }
        }
        public JsonResult GetFechasReservadas()
        {
            try
            {
                IServiceReservacionAreasComunes serviceReservacionAreasComunes = new ServiceReservacionAreasComunes();
                var fechasReservadas= serviceReservacionAreasComunes.GetFechasReservadas();
                return Json(fechasReservadas, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos!" + ex.Message;
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult AceptarReserva(int id)
        {
            try
            {
                IServiceReservacionAreasComunes serviceReservacionAreasComunes = new ServiceReservacionAreasComunes();
                serviceReservacionAreasComunes.AceptarReserva(id);
                return RedirectToAction("IndexAdmin");
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