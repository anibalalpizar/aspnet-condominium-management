using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IRepositoryPlanCobro
    {
        IEnumerable<PLAN_COBRO> GetPlanCobro();
        PLAN_COBRO GetPlanCobroById(int id);
        PLAN_COBRO Save(PLAN_COBRO plan, string[] selectRubrosCobros);
        void Delete(int id);
    }
}
