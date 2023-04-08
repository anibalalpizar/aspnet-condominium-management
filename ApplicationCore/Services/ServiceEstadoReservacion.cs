using Infraestructure.Model;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceEstadoReservacion : IServiceEstadoReservacion
    {
        public IEnumerable<ESTADO_RESERVACION> GetEstadoReservacion()
        {
           IRepositoryEstadoReservacion repositoryEstadoReservacion = new RepositoryEstadoReservacion();
            return repositoryEstadoReservacion.GetEstadoReservacion();
        }
    }
}
