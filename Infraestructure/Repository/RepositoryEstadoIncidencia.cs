using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class RepositoryEstadoIncidencia : IRepositoryEstadoIncidencia
    {
        public IEnumerable<ESTADO_INCIDENCIA> getEstadoDeuda()
        {
            try
            {
                List<ESTADO_INCIDENCIA> list = null;
                using(MyContext ctx = new MyContext())
                {
                    list = ctx.ESTADO_INCIDENCIA.ToList();
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

        public ESTADO_INCIDENCIA getEstadoDeudaById(int id)
        {
            ESTADO_INCIDENCIA estado = null;
            try
            {
                using(MyContext ctx = new MyContext())
                {
                    estado= ctx.ESTADO_INCIDENCIA.Find(id);
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
