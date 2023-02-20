using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class RepositoryPlanCobro : IRepositoryPlanCobro
    {
        public IEnumerable<GESTION_PLANES_COBRO> GetPlanCobro()
        {
            List<GESTION_PLANES_COBRO> listaPlanesCobro = new List<GESTION_PLANES_COBRO>();
            try
            {
                using (CONDOMINIOSEntities ctx = new CONDOMINIOSEntities())
                {
                    listaPlanesCobro = ctx.GESTION_PLANES_COBRO.Include(x => x.USUARIO).ToList();
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
            }
            return listaPlanesCobro;
        }
    }
}
