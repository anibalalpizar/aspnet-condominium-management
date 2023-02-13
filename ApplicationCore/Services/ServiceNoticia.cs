using Infraestructure.Model;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceNoticia : IServiceNoticia
    {
        public IEnumerable<NOTICIA> GetNoticias()
        {
            IRepositoryNoticia repository = new RepositoryNoticia();
            return repository.GetNoticias();
        }
    }
}
