using Infraestructure.Model;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceGestionPlanesCobro : IServiceGestionPlanesCobro
    {
        public IEnumerable<GESTION_PLANES_COBRO> getGestionPlanesCobro()
        {
            IRepositoryGestionPlanesCobro repositoryGestionPlanesCobro = new RepositoryGestionPlanesCobro();
            return repositoryGestionPlanesCobro.getGestionPlanesCobro();
        }

        public GESTION_PLANES_COBRO getGestionPlanesCobroById(int id)
        {
            IRepositoryGestionPlanesCobro repositoryGestionPlanesCobro = new RepositoryGestionPlanesCobro();
            return repositoryGestionPlanesCobro.getGestionPlanesCobroById(id);
        }

        public IEnumerable<GESTION_PLANES_COBRO> getGestionPlanesCobroVigentes()
        {
            IRepositoryGestionPlanesCobro repositoryGestionPlanesCobro = new RepositoryGestionPlanesCobro();
            return repositoryGestionPlanesCobro.getGestionPlanesCobroVigentes();
        }

        public Task<GESTION_PLANES_COBRO> RealizarPago(int id)
        {
            IRepositoryGestionPlanesCobro repositoryGestionPlanesCobro = new RepositoryGestionPlanesCobro();
            return repositoryGestionPlanesCobro.RealizarPago(id);
        }

        public GESTION_PLANES_COBRO Save(GESTION_PLANES_COBRO gestion)
        {
            IRepositoryGestionPlanesCobro repositoryGestionPlanesCobro = new RepositoryGestionPlanesCobro();
            return repositoryGestionPlanesCobro.Save(gestion);
        }
    }
}
