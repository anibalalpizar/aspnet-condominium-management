using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using static System.Collections.Specialized.BitVector32;
using System.Security.Cryptography.Xml;

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
                   // listaPlanesCobro = ctx.GESTION_PLANES_COBRO.Include(x => x.USUARIO).ToList();
                   listaPlanesCobro = ctx.GESTION_PLANES_COBRO.Include(u => u.USUARIO).Include(u => u.ESTADO_DEUDA).ToList();
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
                     .Include("USUARIO").Include("ESTADO_DEUDA").FirstOrDefault();
                  
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

        public GESTION_PLANES_COBRO Save(GESTION_PLANES_COBRO plan, string[] selectRubrosCobros)
        {
           

            try
            {
                int retorno = 0;
                GESTION_PLANES_COBRO gestion = null;
              

                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    gestion = GetPlanCobroById((int)plan.ID_PLAN_COBRO);
                    IRepositoryRubrosCobros repositoryRubrosCobros = new RepositoryRubrosCobros();

                    if (gestion == null)
                    {

                        if (selectRubrosCobros != null)
                        {
                            //Insertar o agregar varios rubros de cobro
                            plan.RUBRO_COBRO = new List<RUBRO_COBRO>();
                            foreach (var rubro in selectRubrosCobros)
                            {
                                var rubroAdd = repositoryRubrosCobros.GetRubroCobrosById(int.Parse(rubro));
                                ctx.RUBRO_COBRO.Attach(rubroAdd);
                                plan.RUBRO_COBRO.Add(rubroAdd);
                            }
                        }
                      
                        //Insertar Plan Cobro
                        ctx.GESTION_PLANES_COBRO.Add(plan);
                        retorno = ctx.SaveChanges();
                    
                    }
                    else
                    {
                        //Actualizar Plan Cobro / Modificar
                                         
                        ctx.GESTION_PLANES_COBRO.Add(plan);
                        ctx.Entry(plan).State = EntityState.Modified;
                        retorno = ctx.SaveChanges();

                        //Actualizar Rubros cobros
                        var selectRubrosId = new HashSet<string>(selectRubrosCobros);
                        if (selectRubrosCobros != null)
                        {
                            ctx.Entry(plan).Collection(r => r.RUBRO_COBRO).Load();
                            var newSelectRubro = ctx.RUBRO_COBRO.Where(x => selectRubrosId.Contains(x.ID_RUBRO_COBRO.ToString())).ToList();
                            plan.RUBRO_COBRO = newSelectRubro;

                            //insertamos los rubros modificados
                            ctx.Entry(plan).State = EntityState.Modified;
                            retorno = ctx.SaveChanges();
                        }
                    }
                   
                }
                //if (retorno > 0)
                //    plan = GetPlanCobroById((int)plan.ID_PLAN_COBRO);
                return gestion;
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
