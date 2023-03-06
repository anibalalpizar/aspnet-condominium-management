using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IRepositoryPlanCobro
    {
        IEnumerable<GESTION_PLANES_COBRO> GetPlanCobro();
        GESTION_PLANES_COBRO GetPlanCobroById(int id);
        GESTION_PLANES_COBRO Save(GESTION_PLANES_COBRO plan);

    }
}
