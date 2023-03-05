using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;

namespace Infraestructure.Repository
{
    public class RepositoryResidencia : IRepositoryResidencia
    {
        public IEnumerable<RESIDENCIA> GetResidencia()
        {
            List<RESIDENCIA> lista = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    lista = ctx.RESIDENCIA.Include(x => x.USUARIO).ToList();
                }
                return lista;
            }
            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }

        public RESIDENCIA GetResidenciaById(int id)
        {
            RESIDENCIA oResidencia = null;
            try
            {
                using (CONDOMINIOSEntities ctx = new CONDOMINIOSEntities())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    oResidencia = ctx.RESIDENCIA.
                        Where(l => l.ID_RESIDENCIA == id).
                        Include(x => x.USUARIO).
                        Include(y => y.ESTADO_RESIDENCIA).
                        FirstOrDefault();
                }
            }
            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
            return oResidencia;
        }
    }
}
