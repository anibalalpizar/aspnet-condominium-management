using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceResidencia
    {
        IEnumerable<RESIDENCIA> GetResidencia();
        IEnumerable<string> GetResidenciaNombres();

        IEnumerable<RESIDENCIA> GetResidenciaByNombre(string nombre);
        IEnumerable<RESIDENCIA> GetResidenciaByAutor(int idAutor);
        IEnumerable<RESIDENCIA> GetResidenciaByCategoria(int idCategoria);
        RESIDENCIA GetResidenciaById(int id);
        RESIDENCIA Save(RESIDENCIA residencia);
        void DeleteResidecia(int id);
        RESIDENCIA Save(RESIDENCIA residencia, string[] selectedCategorias);
    }
}
