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
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult IndexAdmin()
        {
            try
            {
                IEnumerable<USUARIO> uSUARIOs = null;
                IServiceUsuario serviceUsuario = new ServiceUsuario();
                uSUARIOs = serviceUsuario.GetUSUARIOs();
                return View(uSUARIOs);
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
            ViewBag.idTipoUsuario= listTipoUsuario();
            ViewBag.idEstadoUsuario= listEstadoUsuario();
            return View();
        }

        private SelectList listTipoUsuario( int usu =0)
        {
            IServiceTipoUsuario serviceTipoUsuario = new ServiceTipoUsuario();
            IEnumerable<TIPO_USUARIO> lista = serviceTipoUsuario.GetTipoUsuario();
            return new SelectList(lista, "ID_TIPO_USUARIO", "TIPO_USUARIO1", usu);
        }

        private SelectList listEstadoUsuario(int usuE = 0)
        {
            IServiceEstadoUsuario serviceEstadoUsuario = new ServiceEstadoUsuario();
            IEnumerable<ESTADO_USUARIO> lista = serviceEstadoUsuario.getEstadoUsuarios();
            return new SelectList(lista, "ID_ESTADO", "ESTADO", usuE);
        }


        [HttpPost]
        public ActionResult Save(USUARIO usuario) 
        {
            try
            {
                IServiceUsuario serviceUsuario = new ServiceUsuario();

                if (ModelState.IsValid)
                {
                    USUARIO usu = serviceUsuario.Save(usuario);
                }
                else
                {
                    ViewBag.idTipoUsuario = listTipoUsuario(usuario.ID_TIPO_USUARIO);
                    ViewBag.idEstadoUsuario = listEstadoUsuario(usuario.ID_ESTADO);

                    if (usuario.ID_USUARIO > 0)
                    {
                        return (ActionResult)View("Edit", usuario);
                    }
                    else
                    {
                        return View("Create", usuario);
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
            ServiceUsuario service = new ServiceUsuario();
            USUARIO usu = null;
            try
            {
                if (id == null)
                {
                    return RedirectToAction("IndexAdmin");
                }

                usu = service.GetUsuarioById(Convert.ToInt32(id));

                if (usu == null)
                {
                    TempData["Message"] = "No existe la incidencia solicitado";
                    TempData["Redirect"] = "RubrosCobros";
                    TempData["Redirect-Action"] = "IndexAdmin";
                    return RedirectToAction("Default", "Error");
                }

                ViewBag.ID_TIPO_USUARIO = listTipoUsuario(usu.ID_TIPO_USUARIO);
                ViewBag.ID_ESTADO = listEstadoUsuario(usu.ID_ESTADO);

                return View(usu);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos!" + ex.Message;
                return RedirectToAction("Default", "Error");
            }
        }

        public ActionResult EditAdmin(int? id)
        {
            ServiceUsuario service = new ServiceUsuario();
            USUARIO usu = null;
            try
            {
                if (id == null)
                {
                    return RedirectToAction("IndexAdmin");
                }

                usu = service.GetUsuarioById(Convert.ToInt32(id));

                if (usu == null)
                {
                    TempData["Message"] = "No existe la incidencia solicitado";
                    TempData["Redirect"] = "RubrosCobros";
                    TempData["Redirect-Action"] = "IndexAdmin";
                    return RedirectToAction("Default", "Error");
                }

                ViewBag.ID_TIPO_USUARIO = listTipoUsuario(usu.ID_TIPO_USUARIO);
                ViewBag.ID_ESTADO = listEstadoUsuario(usu.ID_ESTADO);

                return View(usu);
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