using Infraestructure.Model;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceResidencia : IServiceResidencia
    {
        public void DeleteResidecia(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RESIDENCIA> GetResidencia()
        {
            IRepositoryResidencia repository = new RepositoryResidencia();
            return repository.GetResidencia();
        }

        public IEnumerable<RESIDENCIA> GetResidenciaByAutor(int idAutor)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RESIDENCIA> GetResidenciaByCategoria(int idCategoria)
        {
            throw new NotImplementedException();
        }

        public RESIDENCIA GetResidenciaById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RESIDENCIA> GetResidenciaByNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetResidenciaNombres()
        {
            throw new NotImplementedException();
        }

        public RESIDENCIA Save(RESIDENCIA residencia, string[] selectedCategorias)
        {
            throw new NotImplementedException();
        }
    }
}
