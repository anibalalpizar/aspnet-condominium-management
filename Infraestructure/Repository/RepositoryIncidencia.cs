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
                using (MyContext ctx = new MyContext())
                {
                    incidencia = ctx.INCIDENCIA.Where(x => x.ID_INCIDENCIA == id).Include("USUARIO").Include("ESTADO_INCIDENCIA").FirstOrDefault();
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

        public IEnumerable<INCIDENCIA> GetIncidencias()
        {
            try
            {
                List<INCIDENCIA> list = null;
                using (MyContext ctx = new MyContext())
                {
                    list = ctx.INCIDENCIA.Include(x => x.ESTADO_INCIDENCIA).Include(x => x.USUARIO).ToList();
                }
                return list;
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

        //Este es para insertar una incidencia en la DB
        public INCIDENCIA Save(INCIDENCIA incidencia)
        {
            int retorno = 0;
            INCIDENCIA Oincidencia = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    Oincidencia = GetIncidenciaById(incidencia.ID_INCIDENCIA);

                    if (Oincidencia == null)
                    {
                        //Insertar 
                        incidencia.ID_ESTADO_INCIDENCIA = 1;
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

                  
                }

                if (retorno > 0)
                    incidencia = GetIncidenciaById((int)incidencia.ID_INCIDENCIA);

                return Oincidencia;
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
