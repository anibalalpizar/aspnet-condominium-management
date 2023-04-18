using Infraestructure.Model;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceReservacionAreasComunes : IServiceReservacionAreasComunes
    {
        public void AceptarReserva(int id)
        {
            IRepositoryReservaAreasComunes repository = new RepositoryReservaAreasComunes();
            repository.AceptarReserva(id);
        }

        public IEnumerable<RESERVA_AREA_COMUN> GetAreasComunes()
        {
            IRepositoryReservaAreasComunes repository = new RepositoryReservaAreasComunes();
            return repository.GetAreasComunes();
        }

        public List<DateTime> GetFechasReservadas()
        {
            IRepositoryReservaAreasComunes repository = new RepositoryReservaAreasComunes();
            return repository.GetFechasReservadas();
        }

        public RESERVA_AREA_COMUN GetReservaById(int id)
        {
            IRepositoryReservaAreasComunes repository = new RepositoryReservaAreasComunes();
            return repository.GetReservaById(id);
        }

        public RESERVA_AREA_COMUN Save(RESERVA_AREA_COMUN area)
        {
            IRepositoryReservaAreasComunes repository = new RepositoryReservaAreasComunes();
            return repository.Save(area);
        }
    }
}