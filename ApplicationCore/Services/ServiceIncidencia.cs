using Infraestructure.Model;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceIncidencia : IServiceIncidencia
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public INCIDENCIA GetIncidenciaById(int id)
        {
            IRepositotyIncidencia repositotyIncidencia = new RepositoryIncidencia();
           return repositotyIncidencia.GetIncidenciaById(id);
        }

        public IEnumerable<INCIDENCIA> GetIncidencias()
        {
            IRepositotyIncidencia repositotyIncidencia = new RepositoryIncidencia();
            return repositotyIncidencia.GetIncidencias();
        }

        public INCIDENCIA Save(INCIDENCIA incidencia)
        {
            IRepositotyIncidencia repositotyIncidencia = new RepositoryIncidencia();
            return repositotyIncidencia.Save(incidencia);
        }
    }
}
