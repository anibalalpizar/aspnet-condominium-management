using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class RepositoryTipoUsuario : IRepositoryTipoUsuario
    {
        public IEnumerable<TIPO_USUARIO> GetTipoUsuario()
        {
			try
			{
				IEnumerable<TIPO_USUARIO> lista = null;
				using(MyContext ctx = new MyContext())
				{
					ctx.Configuration.LazyLoadingEnabled = false;
					lista = ctx.TIPO_USUARIO.ToList<TIPO_USUARIO>();
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
