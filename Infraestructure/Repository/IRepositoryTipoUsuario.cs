using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IRepositoryTipoUsuario
    {
        IEnumerable<TIPO_USUARIO> GetTipoUsuario();
    }
}
