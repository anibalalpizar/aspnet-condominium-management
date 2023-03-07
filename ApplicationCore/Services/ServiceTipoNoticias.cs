using Infraestructure.Model;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceTipoNoticias : IServiceTipoNoticias
    {
        public IEnumerable<TIPO_NOTICIA> GetTipoNoticias()
        {
            IRepositoryTipoNoticia repository = new RepositoryTipoNoticia();
            return repository.GetTipoNoticias();
        }
    }
}
