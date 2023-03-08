using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using static System.Collections.Specialized.BitVector32;

namespace Infraestructure.Repository
{
    public class RepositoryPlanCobro : IRepositoryPlanCobro
    {
        public void Delete(int id)
        {
            try
            {
                GESTION_PLANES_COBRO gestion = null;
                using(MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    gestion = GetPlanCobroById(id);

                    if (gestion != null )
                    {
                        ctx.GESTION_PLANES_COBRO.Remove(gestion);
                        ctx.SaveChanges();
                    }
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
        }

        public IEnumerable<GESTION_PLANES_COBRO> GetPlanCobro()
        {
            List<GESTION_PLANES_COBRO> listaPlanesCobro = new List<GESTION_PLANES_COBRO>();
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    listaPlanesCobro = ctx.GESTION_PLANES_COBRO.Include(x => x.USUARIO).ToList();
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
            return listaPlanesCobro;
        }

        public GESTION_PLANES_COBRO GetPlanCobroById(int id)
        {
            GESTION_PLANES_COBRO planCobro = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                   planCobro = ctx.GESTION_PLANES_COBRO.Where(x => x.ID_PLAN_COBRO == id)
                     .Include(u => u.USUARIO).FirstOrDefault();
                   // planCobro = ctx.GESTION_PLANES_COBRO.Find(id);
                }
                return planCobro;
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

        public GESTION_PLANES_COBRO Save(GESTION_PLANES_COBRO plan)
        {
           

            try
            {
                int retorno = 0;
                GESTION_PLANES_COBRO gestion = null;
              

                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    gestion = GetPlanCobroById((int)plan.ID_PLAN_COBRO);


                    if (gestion == null)
                    {
                        //Insertar Plan Cobro
                        ctx.GESTION_PLANES_COBRO.Add(plan);
                        retorno = ctx.SaveChanges();
                    }
                    else
                    {
                        //Actualizar Plan Cobro / Modificar
                       // gestion.ID_RESIDENTE = plan.ID_RESIDENTE; // Establecer la llave foránea
                        ctx.GESTION_PLANES_COBRO.Add(plan);
                        ctx.Entry(gestion).State = EntityState.Modified;
                       // ctx.Entry(gestion).CurrentValues.SetValues(plan);
                        retorno = ctx.SaveChanges();
                    }
                    return gestion;
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
        }
    }
}
//gestion.ID_RESIDENTE = plan.ID_RESIDENTE; // Establecer la llave foránea