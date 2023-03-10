using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IRepositoryEstadoIncidencia
    {
        IEnumerable<ESTADO_INCIDENCIA> getEstadoDeuda();
        ESTADO_INCIDENCIA getEstadoDeudaById(int id);
    }
}
