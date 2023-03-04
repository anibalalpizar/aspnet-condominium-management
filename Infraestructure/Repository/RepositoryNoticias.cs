using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class RepositoryNoticias : IRepositoryNoticias
    {
        public IEnumerable<NOTICIA> GetNoticias()
        {
            List<NOTICIA> list = null;
            using (MyContext ctx = new MyContext())
            {
                list = ctx.NOTICIA.Include(x => x.TIPO_NOTICIA).ToList();
            }
            return list;
        }
    }
}
