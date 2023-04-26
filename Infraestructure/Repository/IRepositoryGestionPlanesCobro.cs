using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IRepositoryGestionPlanesCobro
    {
        IEnumerable<GESTION_PLANES_COBRO> getGestionPlanesCobro();
        IEnumerable<GESTION_PLANES_COBRO> getGestionPlanesCobroVigentes();
        GESTION_PLANES_COBRO getGestionPlanesCobroById(int id);
        GESTION_PLANES_COBRO Save(GESTION_PLANES_COBRO gestion);
        Task<GESTION_PLANES_COBRO> RealizarPago(int id);
       
    }
}
