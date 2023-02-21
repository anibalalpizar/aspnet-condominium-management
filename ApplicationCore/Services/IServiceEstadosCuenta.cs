using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceEstadosCuenta
    {
        IEnumerable<GESTION_DEUDA> GetEstadosCuenta();
        GESTION_DEUDA GetEstadosCuentaById(int id);
    }
}
