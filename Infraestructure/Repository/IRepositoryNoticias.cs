using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IRepositoryNoticias
    {
        IEnumerable<NOTICIA> GetNoticias();
        NOTICIA Save(NOTICIA noticia);
    }
}
