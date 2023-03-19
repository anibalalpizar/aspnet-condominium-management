using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IRepositoryEstadoUsuario
    {
        IEnumerable<ESTADO_USUARIO> getEstadoUsuarios();
    }
}
