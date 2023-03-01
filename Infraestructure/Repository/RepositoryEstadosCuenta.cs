using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

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
                        .Include(g => g.ESTADO_DEUDA)
                        .Include(g => g.RESIDENCIA.USUARIO)
                        .Include(g => g.PLAN_COBRO)
                        .Where(g => g.ESTADO_DEUDA.NOMBRE_ESTADO_DEUDA == "PENDIENTE")
                        .ToList();

                    //if (list.Count > 0)
                    //{
                    //    var mes = list[0].MES.ToString("MMMM");
                    //    var planCobro = ctx.PLAN_COBRO.Find(list[0].RESIDENCIA.GESTION_DEUDA);
                    //    var totalPagar = planCobro.RUBRO_COBRO.Sum(r => r.MONTO);
                    //}
                }
            }
            catch
            {
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
                        .Include(g => g.ESTADO_DEUDA)
                        .Include(g => g.RESIDENCIA.USUARIO)
                        //.Include(f => f.RESIDENCIA.PLAN_COBRO)
                        .Where(g => g.ESTADO_DEUDA.NOMBRE_ESTADO_DEUDA == "PAGADO")                    
                        .ToList();
                    
                    if (list.Count > 0)
                    {
                        //var planCobro = ctx.PLAN_COBRO.Find(list[0].RESIDENCIA.ID_PLAN_COBRO);
                        foreach (var deuda in list)
                        {
                            var mes = System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(deuda.MES);
                            //var totalPagado = planCobro.RUBRO_COBRO.Where(r => r.ID_RUBRO_COBRO == deuda.ID_ESTADO_DEUDA).Select(r => r.MONTO).SingleOrDefault();
                            //deuda.TOTALPAGAR = totalPagado;
                        }
                    }
                }
            }
            catch
            {
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
                    //list = ctx.GESTION_DEUDA.Include("RESIDENCIA.USUARIO").ToList();

                    list = ctx.GESTION_DEUDA
                       .Include(g => g.ESTADO_DEUDA)
                       .Include(g => g.RESIDENCIA.USUARIO)
                       .ToList();
                }
            }
            catch
            {
                throw;
            }
            return list;
        }

        public GESTION_DEUDA GetEstadosCuentaById(int id)
        {
            GESTION_DEUDA oGestionDeuda = null;
            using (MyContext ctx = new MyContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                oGestionDeuda = ctx.GESTION_DEUDA.
                    Where(l => l.ID_GESTION_DEUDA == id).
                    Include(x => x.RESIDENCIA).
                    Include(y => y.RESIDENCIA.USUARIO).
                    Include(z => z.RESIDENCIA.ESTADO_RESIDENCIA).
                    FirstOrDefault();
            }
            return oGestionDeuda;
        }
    }
}
