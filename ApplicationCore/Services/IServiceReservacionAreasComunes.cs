using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceReservacionAreasComunes
    {
        IEnumerable<RESERVA_AREA_COMUN> GetAreasComunes();
        RESERVA_AREA_COMUN GetReservaById(int id);
        void AceptarReserva(int id);
        List<DateTime> GetFechasReservadas();
        RESERVA_AREA_COMUN Save(RESERVA_AREA_COMUN area);
    }
}
