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
                lista = ctx.RESIDENCIA.Include(x => x.USUARIO).ToList();
            }
            return lista;
        }

        public RESIDENCIA GetResidenciaById(int id)
        {
            RESIDENCIA oResidencia = null;
            try
            {
                using (CONDOMINIOSEntities ctx = new CONDOMINIOSEntities())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    oResidencia = ctx.RESIDENCIA.
                        Where(l => l.ID_RESIDENCIA == id).
                        Include(x => x.USUARIO).
                        Include(y => y.ESTADO_RESIDENCIA).
                        FirstOrDefault();
                }
            }
            catch
            {
                throw;
            }
            return oResidencia;
        }
    }
}
