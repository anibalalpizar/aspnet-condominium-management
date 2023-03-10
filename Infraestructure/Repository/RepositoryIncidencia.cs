using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class RepositoryIncidencia : IRepositotyIncidencia
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        //Este metodo es para traer la incidencia mediante el ID
        public INCIDENCIA GetIncidenciaById(int id)
        {
            INCIDENCIA incidencia = null;
            try
            {
                using(MyContext ctx = new MyContext())
                {
                    incidencia = ctx.INCIDENCIA.Find(id);
                }

                return incidencia;
            }
            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }

        //Este es para traer las todas las incidencias mediante una lista
        public IEnumerable<INCIDENCIA> GetIncidencias()
        {
            List<INCIDENCIA> incidencias = null;
            try
            {
                using(MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    incidencias= ctx.INCIDENCIA.ToList();
                }
            }
            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
            return incidencias;
        }

        //Este es para insertar una incidencia en la DB
        public INCIDENCIA Save(INCIDENCIA incidencia)
        {
            int retorno = 0;
            INCIDENCIA Oincidencia = null;
            try
            {
                using(MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled=false;
                    Oincidencia = GetIncidenciaById(incidencia.ID_INCIDENCIA);

                    if(Oincidencia == null)
                    {
                        //Insertar 
                        ctx.INCIDENCIA.Add(incidencia);
                        retorno = ctx.SaveChanges();
                    }
                    else
                    {
                        //Modificar
                        ctx.INCIDENCIA.Add(incidencia);
                        ctx.Entry(incidencia).State = EntityState.Modified;
                        retorno = ctx.SaveChanges();
                    }

                    return Oincidencia;
                }
            }
            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }
    }
}
