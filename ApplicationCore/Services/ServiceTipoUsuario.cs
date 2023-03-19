using Infraestructure.Model;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceTipoUsuario : IServiceTipoUsuario
    {
        public IEnumerable<TIPO_USUARIO> GetTipoUsuario()
        {
            IRepositoryTipoUsuario repositoryTipoUsuario = new RepositoryTipoUsuario();
            return repositoryTipoUsuario.GetTipoUsuario();
        }
    }
}
