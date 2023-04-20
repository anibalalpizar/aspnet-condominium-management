using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;

namespace Infraestructure.Repository
{
    public class RepositoryResidencia : IRepositoryResidencia
    {
        public IEnumerable<RESIDENCIA> GetResidencia()
        {
            List<RESIDENCIA> lista = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    lista = ctx.RESIDENCIA.Include(x => x.USUARIO).Include(x => x.ESTADO_RESIDENCIA).ToList();
                }
                return lista;
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

        public RESIDENCIA GetResidenciaById(int id)
        {
            RESIDENCIA oResidencia = null;
            try
            {
                using (CONDOMINIOSEntities ctx = new CONDOMINIOSEntities())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    oResidencia = ctx.RESIDENCIA.
                        Where(l => l.ID_RESIDENCIA == id).
                        Include(x => x.USUARIO).
                        Include(y => y.ESTADO_RESIDENCIA).
                        FirstOrDefault();
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
            return oResidencia;
        }

        public RESIDENCIA Save(RESIDENCIA residencia)
        {
            try
            {
                int retorno = 0;
                RESIDENCIA oResidencia = null;

                using(MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    oResidencia = GetResidenciaById(residencia.ID_RESIDENCIA);
                    if (oResidencia == null)
                    {
                        residencia.ID_ESTADO_RESIDENCIA = 2;
                        ctx.RESIDENCIA.Add(residencia);
                        retorno = ctx.SaveChanges();
                    }
                    else
                    {
                        ctx.RESIDENCIA.Add(residencia);
                        ctx.Entry(residencia).State = EntityState.Modified;
                        retorno = ctx.SaveChanges();
                    }
                    if (retorno > 0)
                    
                        residencia = GetResidenciaById(residencia.ID_RESIDENCIA);
                    return oResidencia;
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
