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
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NOTICIA> GetNoticias()
        {
            IRepositoryNoticias _repositoryNoticias = new RepositoryNoticias();
            return _repositoryNoticias.GetNoticias();
        }

        public NOTICIA GetNoticiasById(int id)
        {
            IRepositoryNoticias repositoryNoticias = new RepositoryNoticias();
            return repositoryNoticias.GetNoticiasById(id);
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