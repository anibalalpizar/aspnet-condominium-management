using Infraestructure.Model;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceEstadoResidencia : IServiceEstadoResidencia
    {
        public IEnumerable<ESTADO_RESIDENCIA> GetEstadoResidencia()
        {
            IRepositoryEstadoResidencia repositoryEstadoResidencia = new RepositoryEstadoResidencia();
            return repositoryEstadoResidencia.GetEstadoResidencia();
        }
    }
}
