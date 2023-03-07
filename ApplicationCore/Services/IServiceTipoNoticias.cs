using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceTipoNoticias
    {
        IEnumerable<TIPO_NOTICIA> GetTipoNoticias();
    }
}
