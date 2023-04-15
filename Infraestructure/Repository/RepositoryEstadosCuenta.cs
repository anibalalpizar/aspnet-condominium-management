using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Infraestructure.Repository
{
    public class RepositoryEstadosCuenta : IRepositoryEstadosCuenta
    {
        public IEnumerable<GESTION_DEUDA> GetDeudasVigentes()
        {
            List<GESTION_DEUDA> list = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;

                    list = ctx.GESTION_DEUDA
                      
                       // .Include(g => g.RESIDENCIA.USUARIO)
                        .Include(g => g.GESTION_PLANES_COBRO)
                     //   .Where(g => g.ESTADO_DEUDA.NOMBRE_ESTADO_DEUDA == "PENDIENTE")
                        .ToList();
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

        public IEnumerable<GESTION_DEUDA> GetHistorialPagos()
        {
            List<GESTION_DEUDA> list = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;

                    list = ctx.GESTION_DEUDA
                     //   .Include(g => g.ESTADO_DEUDA)
                      //  .Include(g => g.RESIDENCIA.USUARIO)
                        .Include(f => f.GESTION_PLANES_COBRO)
                     //   .Where(g => g.ESTADO_DEUDA.NOMBRE_ESTADO_DEUDA == "PAGADO")
                        .ToList();

                    if (list.Count > 0)
                    {
                        foreach (var deuda in list)
                        {
                            var mes = System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(deuda.MES);
                        }
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
            return list;
        }

        public IEnumerable<GESTION_DEUDA> GetEstadosCuenta()
        {
            List<GESTION_DEUDA> list = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;

                    list = ctx.GESTION_DEUDA
                     //  .Include(g => g.ESTADO_DEUDA)
                    //   .Include(g => g.RESIDENCIA.USUARIO)
                       .ToList();
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

        public GESTION_DEUDA GetEstadosCuentaById(int id)
        {
            GESTION_DEUDA oGestionDeuda = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    oGestionDeuda = ctx.GESTION_DEUDA.Where(l => l.ID_GESTION_DEUDA == id).
                      //  Include(z => z.RESIDENCIA.ESTADO_RESIDENCIA).
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
            return oGestionDeuda;
        }
    }
}
