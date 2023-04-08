using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class RepositoryEstadoReservacion : IRepositoryEstadoReservacion
    {
        public IEnumerable<ESTADO_RESERVACION> GetEstadoReservacion()
        {
			try
			{
				List<ESTADO_RESERVACION> lista = null;
				using(MyContext ctx = new MyContext())
				{
					ctx.Configuration.LazyLoadingEnabled = false;
					lista = ctx.ESTADO_RESERVACION.ToList<ESTADO_RESERVACION>();
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
    }
}
