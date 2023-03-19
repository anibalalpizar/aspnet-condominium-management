using Infraestructure.Model;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceUsuario : IServiceUsuario
    {
        public USUARIO GetUsuarioById(int id)
        {
            IRepositoryUsuario repositoryUsuario = new RepositoryUsuario();
            return repositoryUsuario.GetUsuarioById(id);
        }

        public IEnumerable<USUARIO> GetUSUARIOs()
        {
            IRepositoryUsuario repositoryUsuario = new RepositoryUsuario();
            return repositoryUsuario.GetUSUARIOs();
        }

        public USUARIO Save(USUARIO usuario)
        {
            IRepositoryUsuario repositoryUsuario = new RepositoryUsuario();
            return repositoryUsuario.Save(usuario);
        }
    }
}
