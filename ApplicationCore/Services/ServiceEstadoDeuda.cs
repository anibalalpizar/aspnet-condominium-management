using Infraestructure.Model;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceEstadoDeuda : IServiceEstadoDeuda
    {
        public IEnumerable<ESTADO_DEUDA> getEstadoDeuda()
        {
            IRepositoryEstadoDeuda repositoryEstadoDeuda = new RepositoryEstadoDeuda();
            return repositoryEstadoDeuda.getEstadoDeuda();
        }

        public ESTADO_DEUDA getEstadoDeudaById(int id)
        {
            IRepositoryEstadoDeuda repositoryEstadoDeuda= new RepositoryEstadoDeuda();
            return repositoryEstadoDeuda.getEstadoDeudaById(id);
        }
    }
}
