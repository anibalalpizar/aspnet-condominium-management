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
        public IEnumerable<RUBRO_COBRO> GetRubrosCobros()
        {
            IRepositoryRubrosCobros repository = new RepositoryRubrosCobros();
            return repository.GetRubrosCobros();
        }
    }
}
