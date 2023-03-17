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
          
        }

        public IEnumerable<PLAN_COBRO> GetPlanCobro()
        {
            List<PLAN_COBRO> listaPlanesCobro = new List<PLAN_COBRO>();
            try
            {
                using (MyContext ctx = new MyContext())
                {
                  ctx.Configuration.LazyLoadingEnabled = false;
                   listaPlanesCobro = ctx.PLAN_COBRO.ToList();
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

        public PLAN_COBRO GetPlanCobroById(int id)
        {
            PLAN_COBRO planCobro = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                   planCobro = ctx.PLAN_COBRO.Where(x => x.ID_COBRO_PLAN == id)
                     .Include("RUBRO_COBRO").FirstOrDefault();
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

        public PLAN_COBRO Save(PLAN_COBRO plan, string[] selectRubrosCobros)
        {
           

            try
            {
                int retorno = 0;
                PLAN_COBRO gestion = null;
              

                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    gestion = GetPlanCobroById((int)plan.ID_COBRO_PLAN);
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
                        ctx.PLAN_COBRO.Add(plan);
                        retorno = ctx.SaveChanges();
                    
                    }
                    else
                    {
                        //Actualizar Plan Cobro / Modificar
                                         
                        ctx.PLAN_COBRO.Add(plan);
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
                if (retorno > 0)
                    plan = GetPlanCobroById((int)plan.ID_COBRO_PLAN);
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
