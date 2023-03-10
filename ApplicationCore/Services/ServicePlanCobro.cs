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
        public void Delete(int id)
        {
            IRepositoryPlanCobro repositoryPlanCobro = new RepositoryPlanCobro();
            repositoryPlanCobro.Delete(id);
        }

        public IEnumerable<GESTION_PLANES_COBRO> GetPlanCobro()
        {
            IRepositoryPlanCobro repository = new RepositoryPlanCobro();
            return repository.GetPlanCobro();
        }

        public GESTION_PLANES_COBRO GetPlanCobroById(int id)
        {
            IRepositoryPlanCobro repository = new RepositoryPlanCobro();
            return repository.GetPlanCobroById(id);
        }

        public GESTION_PLANES_COBRO Save(GESTION_PLANES_COBRO plan)
        {
            IRepositoryPlanCobro repositoryPlanCobro = new RepositoryPlanCobro();
            return repositoryPlanCobro.Save(plan);
        }
    }
}