using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class RepositoryResidencia : IRepositoryResidencia
    {
        public IEnumerable<RESIDENCIA> GetResidencia()
        {
            List<RESIDENCIA> lista = null;
            using (MyContext ctx = new MyContext())
            {
                // lista = ctx.RESIDENCIA.ToList();
                lista = ctx.RESIDENCIA.Include(x => x.USUARIO).ToList();
            }
            return lista;
        }
    }
}
