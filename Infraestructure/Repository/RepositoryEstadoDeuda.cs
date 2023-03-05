using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class RepositoryEstadoDeuda : IRepositoryEstadoDeuda
    {
        public IEnumerable<ESTADO_DEUDA> getEstadoDeuda()
        {
            try
            {
                List<ESTADO_DEUDA> list = null;
                using (MyContext ctx = new MyContext())
                {
                    list = ctx.ESTADO_DEUDA.ToList<ESTADO_DEUDA>();
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
    

        public ESTADO_DEUDA getEstadoDeudaById(int id)
        {
            ESTADO_DEUDA estado = null;
            try
            {
                
                using (MyContext ctx = new MyContext())
                {
                    estado = ctx.ESTADO_DEUDA.Find(id);
                }
                return estado;
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
