using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class RepositoryNoticia : IRepositoryNoticia
    {
        public IEnumerable<NOTICIA> GetNoticias()
        {
            try
            {
                IEnumerable<NOTICIA> lista = null;
                using(MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.NOTICIAs.ToList<NOTICIA>();
                }
                return lista;
            }
            catch
            {
                throw;
            }
        }
    }
}
