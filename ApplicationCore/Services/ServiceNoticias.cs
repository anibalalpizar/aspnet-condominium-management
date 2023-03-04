using Infraestructure.Model;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceNoticias : IServiceNoticias
    {
        public IEnumerable<NOTICIA> GetNoticias()
        {
            IRepositoryNoticias _repositoryNoticias = new RepositoryNoticias();
            return _repositoryNoticias.GetNoticias();
        }
    }
}
