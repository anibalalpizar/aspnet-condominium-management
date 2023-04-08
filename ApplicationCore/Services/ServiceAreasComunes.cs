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
        public IEnumerable<AREA_COMUN> GetAreaComun()
        {
            IRepositoryAreasComunes repositoryAreasComunes = new RepositoryAreasComunes();
            return repositoryAreasComunes.GetAreaComun();
        }
    }
}
