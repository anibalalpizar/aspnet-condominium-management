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
                using (MyContext ctx = new MyContext())
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

        public GESTION_PLANES_COBRO GetPlanCobroById(int id)
        {
            GESTION_PLANES_COBRO planCobro = new GESTION_PLANES_COBRO();
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    planCobro = ctx.GESTION_PLANES_COBRO.Where(x => x.ID_PLAN_COBRO == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
            }
            return planCobro;
        }
    }
}
