using Infraestructure.Model;
using Infraestructure.Repository;
using System;
using ApplicationCore.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceUsuario : IServiceUsuario
    {
        public USUARIO GetUsuario(string email, string password)
        {
            IRepositoryUsuario repositoryUsuario = new RepositoryUsuario();
            string passwordEncrypt = Cryptography.EncrypthAES(password);
            return repositoryUsuario.GetUsuario(email, passwordEncrypt);
        }

        public USUARIO GetUsuarioById(int id)
        {
            IRepositoryUsuario repositoryUsuario = new RepositoryUsuario();
            USUARIO oUsuario = repositoryUsuario.GetUsuarioById(id);
            // Desencriptar el password para mostrarlo en la vista
            oUsuario.CONTRASENA = Cryptography.DecrypthAES(oUsuario.CONTRASENA);
            return oUsuario;
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
