using Infraestructure.Model;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceRubrosCobros : IServiceRubrosCobros
    {
        public void Delete(int id)
        {
            IRepositoryRubrosCobros repositoryRubrosCobros = new RepositoryRubrosCobros();  
            repositoryRubrosCobros.Delete(id);
        }

        public RUBRO_COBRO GetRubroCobrosById(int id)
        {
            IRepositoryRubrosCobros repositoryRubrosCobros = new RepositoryRubrosCobros(); ;
            return repositoryRubrosCobros.GetRubroCobrosById(id);
        }

        public IEnumerable<RUBRO_COBRO> GetRubrosCobros()
        {
            IRepositoryRubrosCobros repository = new RepositoryRubrosCobros();
            return repository.GetRubrosCobros();
        }

        public RUBRO_COBRO Save(RUBRO_COBRO plan)
        {
            IRepositoryRubrosCobros repositoryRubrosCobros= new RepositoryRubrosCobros(); ;
            return repositoryRubrosCobros.Save(plan);
        }
    }
}
