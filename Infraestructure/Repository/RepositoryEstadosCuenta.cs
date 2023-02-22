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
                        .Where(g => g.ESTADO_DEUDA.NOMBRE_ESTADO_DEUDA == "PENDIENTE")
                        .ToList();

                    if (list.Count > 0)
                    {
                        var mes = list[0].MES.ToString("MMMM");
                        var planCobro = ctx.PLAN_COBRO.Find(list[0].RESIDENCIA.ID_PLAN_COBRO);
                        var totalPagar = planCobro.RUBRO_COBRO.Sum(r => r.MONTO);
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
