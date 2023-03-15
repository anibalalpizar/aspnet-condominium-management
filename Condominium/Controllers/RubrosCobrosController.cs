using ApplicationCore.Services;
using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos!" + ex.Message;
                return RedirectToAction("Default", "Error");
            }

        }

        //Vista del Administrador
        //Get de todos los rubros de cobro
        public ActionResult IndexAdmin() 
        {
            IEnumerable<RUBRO_COBRO> list = null;
            try
            {
                IServiceRubrosCobros serviceRubrosCobros = new ServiceRubrosCobros();
                list = serviceRubrosCobros.GetRubrosCobros();
                return View(list);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos!" + ex.Message;
                return RedirectToAction("Default", "Error");
            }
        }

        //Crear Rubro de cobro
        [HttpGet]
        public ActionResult Create() 
        {
            return View();
        }

        //Guardar rubro de cobro
        [HttpPost]
        public ActionResult Save(RUBRO_COBRO cobro, HttpPostedFileBase ImageFile, HttpPostedFileBase nuevo)
        {
            MemoryStream target = new MemoryStream();
            IServiceRubrosCobros serviceRubrosCobros = new ServiceRubrosCobros();

            try
            {
            
                if (cobro.IMAGEN == null)
                {
                    if(ImageFile != null)
                    {
                        ImageFile.InputStream.CopyTo(target);
                        cobro.IMAGEN = target.ToArray();
                        ModelState.Remove("IMAGEN");
                    }
                }
                else
                {
                  
                        if (nuevo != null)
                        {
                            nuevo.InputStream.CopyTo(target);
                            cobro.IMAGEN = target.ToArray();
                            ModelState.Remove("IMAGEN");
                        }
                    
                }


                if(ModelState.IsValid)
                {
                    RUBRO_COBRO oRubro = serviceRubrosCobros.Save(cobro);

                }
                return RedirectToAction("IndexAdmin");
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "RubrosCobros";
                TempData["Redirect-Action"] = "IndexAdmin";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }
        

        //Editar Rubros de cobro
        public ActionResult Edit(int? id) 
        {
            ServiceRubrosCobros serviceRubrosCobros = new ServiceRubrosCobros();
            RUBRO_COBRO rubro = null;

            try
            {
                if(id == null)
                {
                    return RedirectToAction("IndexAdmin");
                }

                rubro = serviceRubrosCobros.GetRubroCobrosById(Convert.ToInt32(id));

                if(rubro == null)
                {
                    TempData["Message"] = "No existe el libro solicitado";
                    TempData["Redirect"] = "RubrosCobros";
                    TempData["Redirect-Action"] = "IndexAdmin";
                    // Redireccion a la captura del Error
                    return RedirectToAction("Default", "Error");
                }

                return View(rubro);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos!" + ex.Message;
                return RedirectToAction("Default", "Error");
            }
        }

        [HttpGet]
        public ActionResult Deleted()
        {
            return View();
        }

        //Eliminar Rubros de cobros
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            ServiceRubrosCobros serviceRubrosCobros = new ServiceRubrosCobros();
            RUBRO_COBRO rubro = null;
            try
            {
                if(id == null)
                {
                    return RedirectToAction("IndexAdmin");
                }

                rubro = serviceRubrosCobros.GetRubroCobrosById(Convert.ToInt32(id));

                if (rubro.BORRADO == 0)
                    {
                        serviceRubrosCobros.Delete(Convert.ToInt32(id));
                    }
                
                
                return View(rubro);
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