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
    }
}
