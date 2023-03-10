using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceIncidencia
    {
        IEnumerable<INCIDENCIA> GetIncidencias();
        INCIDENCIA GetIncidenciaById(int id);
        INCIDENCIA Save(INCIDENCIA incidencia);
        void Delete(int id);
    }
}
