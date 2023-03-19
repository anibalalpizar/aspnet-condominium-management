using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class RepositoryEstadoUsuario : IRepositoryEstadoUsuario
    {
        public IEnumerable<ESTADO_USUARIO> getEstadoUsuarios()
        {
			try
			{
				IEnumerable<ESTADO_USUARIO> lista = null;
				using (MyContext ctx = new MyContext())
				{
					ctx.Configuration.LazyLoadingEnabled = false;
					lista = ctx.ESTADO_USUARIO.ToList <ESTADO_USUARIO>();
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
