using Infraestructure.Model;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServicePlanCobro : IServicePlanCobro
    {
        public IEnumerable<GESTION_PLANES_COBRO> GetPlanCobro()
        {
            IRepositoryPlanCobro repository = new RepositoryPlanCobro();
            return repository.GetPlanCobro();
        }
    }
}
