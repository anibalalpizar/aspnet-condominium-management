using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceEstadoIncidencia
    {
        IEnumerable<ESTADO_INCIDENCIA> getEstadoDeuda();
        ESTADO_INCIDENCIA getEstadoDeudaById(int id);
    }
}
