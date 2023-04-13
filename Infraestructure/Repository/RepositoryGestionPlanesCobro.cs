using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class RepositoryGestionPlanesCobro : IRepositoryGestionPlanesCobro
    {
        public IEnumerable<GESTION_PLANES_COBRO> getGestionPlanesCobro()
        {
            try
            {
                List<GESTION_PLANES_COBRO> lista = null;
                using(MyContext ctx = new MyContext())
                {
                   lista = ctx.GESTION_PLANES_COBRO.Include("RESIDENCIA").Include("PLAN_COBRO").Include("ESTADO_DEUDA"). ToList();
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

        //public IEnumerable<GESTION_PLANES_COBRO> getGestionPlanesCobroVigentes()
        //{
        //    try
        //    {
        //        List<GESTION_PLANES_COBRO> lista = null;
        //        using (MyContext ctx = new MyContext())
        //        {
        //            if ()
        //            {

        //            }
        //            lista = ctx.GESTION_PLANES_COBRO.Include("RESIDENCIA").Include("PLAN_COBRO").Include("ESTADO_DEUDA").ToList();
        //        }

        //        return lista;
        //    }
        //    catch (DbUpdateException dbEx)
        //    {
        //        string mensaje = "";
        //        Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
        //        throw new Exception(mensaje);
        //    }
        //    catch (Exception ex)
        //    {
        //        string mensaje = "";
        //        Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
        //        throw;
        //    }
        //}

        public GESTION_PLANES_COBRO getGestionPlanesCobroById(int id)
        {
            try
            {
                GESTION_PLANES_COBRO oGestion = null;
                using(MyContext ctx = new MyContext())
                {
                    oGestion= ctx.GESTION_PLANES_COBRO.Where(x => x.ID_GESTION_PLANES_COBRO == id).
                  Include("RESIDENCIA").
                  Include("PLAN_COBRO").
                  Include("ESTADO_DEUDA").
                  FirstOrDefault();
                }

                return oGestion;


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

       

        public GESTION_PLANES_COBRO Save(GESTION_PLANES_COBRO gestion)
        {
            try
            {
                int retorno = 0;
                GESTION_PLANES_COBRO oGestion = null;

                using(MyContext ctx = new MyContext())
                {
                    oGestion = getGestionPlanesCobroById(gestion.ID_GESTION_PLANES_COBRO);

                    if (oGestion == null)
                    {
                        ctx.GESTION_PLANES_COBRO.Add(gestion);
                        retorno = ctx.SaveChanges();
                    }
                    else
                    {
                        ctx.GESTION_PLANES_COBRO.Add(gestion);
                        ctx.Entry(gestion).State = EntityState.Modified;
                        retorno = ctx.SaveChanges();
                    }
                }
                //if (retorno > 0)
                //    oGestion = getGestionPlanesCobroById((int)gestion.ID_GESTION_PLANES_COBRO);
                return oGestion;
            }
            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (DbEntityValidationException ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }
    }
}
