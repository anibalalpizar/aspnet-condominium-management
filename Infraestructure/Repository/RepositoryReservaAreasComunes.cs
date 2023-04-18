using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;

namespace Infraestructure.Repository
{
    public class RepositoryReservaAreasComunes : IRepositoryReservaAreasComunes
    {
       

        public IEnumerable<RESERVA_AREA_COMUN> GetAreasComunes()
        {
            IEnumerable<RESERVA_AREA_COMUN> lista = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.RESERVA_AREA_COMUN.Include(x => x.USUARIO).Include(x => x.AREA_COMUN).Include(x => x.ESTADO_RESERVACION).ToList();
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

        public RESERVA_AREA_COMUN GetReservaById(int id)
        {
            try
            {
                RESERVA_AREA_COMUN reserva = null;
                using(MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    reserva = ctx.RESERVA_AREA_COMUN.Where(x => x.ID_RESERVA_AREA_COMUN == id).Include("USUARIO").Include("AREA_COMUN").Include("ESTADO_RESERVACION").FirstOrDefault();
                }
                return reserva;
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

        public void AceptarReserva(int id)
        {
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    var reserva = ctx.RESERVA_AREA_COMUN.FirstOrDefault(r => r.ID_RESERVA_AREA_COMUN == id);

                    if (reserva != null && reserva.ID_ESTADO_RESERVACION != 2) 
                    {
                        reserva.ID_ESTADO_RESERVACION = 2;
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

        public RESERVA_AREA_COMUN Save(RESERVA_AREA_COMUN area)
        {
            try
            {
                int retorno = 0;
                RESERVA_AREA_COMUN reserva = null;
                using( MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    reserva = GetReservaById(area.ID_RESERVA_AREA_COMUN);

                    if (reserva == null)
                    {
                        area.ID_ESTADO_RESERVACION = 1;
                        ctx.RESERVA_AREA_COMUN.Add(area);
                        retorno= ctx.SaveChanges();
                    }
                    else
                    {
                        ctx.RESERVA_AREA_COMUN.Add(area);
                        ctx.Entry(area).State = EntityState.Modified;
                        retorno = ctx.SaveChanges();
                    }
                }

                if (retorno > 0)
                    area = GetReservaById((int)area.ID_RESERVA_AREA_COMUN);

                return reserva;
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

        

        public List<DateTime> GetFechasReservadas()
        {
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    var fechasReservadas = ctx.RESERVA_AREA_COMUN
                 .Select(r => EntityFunctions.TruncateTime(r.FECHA_RESERVA))
                 .ToList()
                 .Select(d => d.Value)
                 .ToList();

                    return fechasReservadas;
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
