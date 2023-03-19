using Infraestructure.Model;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceEstadoUsuario : IServiceEstadoUsuario
    {
        public IEnumerable<ESTADO_USUARIO> getEstadoUsuarios()
        {
            IRepositoryEstadoUsuario repositoryEstadoUsuario = new RepositoryEstadoUsuario();
            return repositoryEstadoUsuario.getEstadoUsuarios();
        }
    }
}
