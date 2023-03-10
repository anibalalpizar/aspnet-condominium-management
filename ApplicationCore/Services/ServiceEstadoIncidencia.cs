using Infraestructure.Model;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceEstadoIncidencia : IServiceEstadoIncidencia
    {
        public IEnumerable<ESTADO_INCIDENCIA> getEstadoDeuda()
        {
            IRepositoryEstadoIncidencia repositoryEstadoIncidencia = new RepositoryEstadoIncidencia();
            return repositoryEstadoIncidencia.getEstadoDeuda();
        }

        public ESTADO_INCIDENCIA getEstadoDeudaById(int id)
        {
            IRepositoryEstadoIncidencia repositoryEstadoIncidencia = new RepositoryEstadoIncidencia();
            return repositoryEstadoIncidencia.getEstadoDeudaById(id);
        }
    }
}
