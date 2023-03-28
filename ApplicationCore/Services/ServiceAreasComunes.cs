using Infraestructure.Model;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceAreasComunes : IServiceAreasComunes
    {
        public IEnumerable<RESERVA_AREA_COMUN> GetAreasComunes()
        {
            IRepositoryReservaAreasComunes repository = new RepositoryReservaAreasComunes();
            return repository.GetAreasComunes();
        }
    }
}
