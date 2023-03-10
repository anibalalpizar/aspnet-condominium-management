using ApplicationCore.Services;
using Condominium.Util;
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
    public class NoticiasController : Controller
    {
        // GET: Noticias
        public ActionResult IndexAdmin()
        {
            IEnumerable<NOTICIA> lista = null;
            try
            {
                IServiceNoticias _serviceNoticia = new ServiceNoticias();
                lista = _serviceNoticia.GetNoticias();
                ViewBag.listaTipoNoticias = _serviceNoticia.GetNoticiaTipo();
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
            ViewBag.idTipoNoticia = listaTiposNoticias();
            return View();
        }

        public SelectList listaTiposNoticias(int idTipoNoticia = 0)
        {
            IServiceTipoNoticias _serviceNoticia = new ServiceTipoNoticias();
            IEnumerable<TIPO_NOTICIA> lista = _serviceNoticia.GetTipoNoticias();
            return new SelectList(lista, "ID_TIPO_NOTICIA", "TIPO_NOTICIA_INFO", idTipoNoticia);
        }

        [HttpPost]
        public ActionResult Save(NOTICIA noticia)
        {
            IServiceNoticias _serviceNoticia = new ServiceNoticias();
            try
            {
                if (ModelState.IsValid)
                {
                    NOTICIA oNoticiaI = _serviceNoticia.Save(noticia);
                }
                else
                {
                    ViewBag.idTipoNoticia = listaTiposNoticias(noticia.ID_NOTICIA);
                    if(noticia.ID_NOTICIA > 0)
                    {
                        return (ActionResult)View("Edit", noticia);
                    }
                    else
                    {
                        return View("Create", noticia);
                    }
                }

                return RedirectToAction("Index");
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


        //Editar las noticias
        public ActionResult Edit(int? id)
        {
            ServiceNoticias _ServiceNoticia = new ServiceNoticias();
            NOTICIA noticia = null;
            try
            {
                if (id == null)
                {
                    return RedirectToAction("Index");
                }

                noticia = _ServiceNoticia.GetNoticiasById(Convert.ToInt32(id));

                if (noticia == null)
                {
                    TempData["Message"] = "No existe la noticia solicitado";
                    TempData["Redirect"] = "RubrosCobros";
                    TempData["Redirect-Action"] = "IndexAdmin";
                    return RedirectToAction("Default", "Error");
                }
                ViewBag.ID_TIPO_NOTICA = listaTiposNoticias(noticia.ID_TIPO_NOTICIA);
                return View(noticia);
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