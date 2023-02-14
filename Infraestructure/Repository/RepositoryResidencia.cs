using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class RepositoryResidencia : IRepositoryResidencia
    {
        public IEnumerable<RESIDENCIA> GetResidencia()
        {
            IEnumerable<RESIDENCIA> lista = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.RESIDENCIAs.Include("USUARIOs").ToList();
                    //lista = ctx.RESIDENCIAs.Include(x => x.
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
