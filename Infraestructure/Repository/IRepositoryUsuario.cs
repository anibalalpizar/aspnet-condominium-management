using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IRepositoryUsuario
    {
        IEnumerable<USUARIO> GetUSUARIOs();
        USUARIO GetUsuarioById(int id);
        USUARIO Save(USUARIO usuario);
    }
}
