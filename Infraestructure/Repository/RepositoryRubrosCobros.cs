using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class RepositoryRubrosCobros : IRepositoryRubrosCobros
    {
        public IEnumerable<RUBRO_COBRO> GetRubrosCobros()
        {
            List<RUBRO_COBRO> list = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    list = ctx.RUBRO_COBRO.ToList();
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
