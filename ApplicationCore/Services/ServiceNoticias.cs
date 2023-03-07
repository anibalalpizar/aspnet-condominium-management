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

        public IEnumerable<string> GetNoticiaTipo()
        {
            IRepositoryNoticias repositoryNoticas = new RepositoryNoticias();
            return repositoryNoticas.GetNoticias().Select(x => x.TITULO);
        }

        public NOTICIA Save(NOTICIA noticia)
        {
            IRepositoryNoticias repository = new RepositoryNoticias();
            return repository.Save(noticia);
        }
    }
}