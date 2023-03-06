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
    public class RepositoryRubrosCobros : IRepositoryRubrosCobros
    {
        public void Delete(int id)
        {
            try
            {
                
                RUBRO_COBRO rubro = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    rubro = GetRubroCobrosById(id);

                    if (rubro != null)
                    {
                        //Eliminar Cobro
                        ctx.RUBRO_COBRO.Remove(rubro);
                        ctx.SaveChanges();
                    }
                   
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

        public RUBRO_COBRO GetRubroCobrosById(int id)
        {
            RUBRO_COBRO rubro = null;

            try
            {
                using (MyContext ctx = new MyContext())
                {
                    rubro = ctx.RUBRO_COBRO.Find(id);
                }
                return rubro;
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

        public IEnumerable<RUBRO_COBRO> GetRubrosCobros()
        {
            List<RUBRO_COBRO> list = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    list = ctx.RUBRO_COBRO.ToList();
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
            return list;
        }

        public RUBRO_COBRO Save(RUBRO_COBRO plan)
        {
            try
            {
                int retorno = 0;
                RUBRO_COBRO rubro = null;
                using(MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    rubro = GetRubroCobrosById((int)plan.ID_RUBRO_COBRO);

                    if (rubro == null)
                    {
                        //Insertar Cobro
                        ctx.RUBRO_COBRO.Add(plan);
                        retorno = ctx.SaveChanges();
                    }
                    else
                    {
                        //Actualizar Cobro / ModificR
                        ctx.RUBRO_COBRO.Add(plan);
                        ctx.Entry(plan).State = EntityState.Modified;
                        retorno = ctx.SaveChanges();

                    }
                    return rubro;
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
