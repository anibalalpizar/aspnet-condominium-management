using Infraestructure.Model;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceEstadosCuenta : IServiceEstadosCuenta
    {
        public IEnumerable<GESTION_DEUDA> GetEstadosCuenta()
        {
            IRepositoryEstadosCuenta repository = new RepositoryEstadosCuenta();
            return repository.GetEstadosCuenta();
        }
    }
}
