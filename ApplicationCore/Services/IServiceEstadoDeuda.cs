using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceEstadoDeuda
    {
        IEnumerable<ESTADO_DEUDA> getEstadoDeuda();
        ESTADO_DEUDA getEstadoDeudaById(int id);
    }
}
