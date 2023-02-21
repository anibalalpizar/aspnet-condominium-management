using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IRepositoryEstadosCuenta
    {
        IEnumerable<GESTION_DEUDA> GetEstadosCuenta();
    }
}
