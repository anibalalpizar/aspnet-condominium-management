using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceRubrosCobros
    {
        IEnumerable<RUBRO_COBRO> GetRubrosCobros();
        RUBRO_COBRO GetRubroCobrosById(int id);
        RUBRO_COBRO Save(RUBRO_COBRO plan);
        void Delete(int id);

    }
}
