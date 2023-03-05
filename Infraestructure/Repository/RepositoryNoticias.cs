using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;

namespace Infraestructure.Repository
{
    public class RepositoryNoticias : IRepositoryNoticias
    {
        public IEnumerable<NOTICIA> GetNoticias()
        {
            try
            {
                List<NOTICIA> list = null;
                using (MyContext ctx = new MyContext())
                {
                    list = ctx.NOTICIA.Include(x => x.TIPO_NOTICIA).ToList();
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
    }
}
