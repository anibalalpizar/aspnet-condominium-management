using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServicePlanCobro
    {
        IEnumerable<GESTION_PLANES_COBRO> GetPlanCobro();
        GESTION_PLANES_COBRO GetPlanCobroById(int id);
    }
}
