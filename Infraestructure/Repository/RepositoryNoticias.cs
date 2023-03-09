using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;

namespace Infraestructure.Repository
{
    public class RepositoryNoticias : IRepositoryNoticias
    {
        public IEnumerable<NOTICIA> GetNoticias()
        {
            try
            {
                List<NOTICIA> list = null;
                using (MyContext ctx = new MyContext())
                {
                    list = ctx.NOTICIA.Include(x => x.TIPO_NOTICIA).ToList();
                }
                return list;
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

        //public NOTICIA GetNoticiaByID(int id)
        //{
        //    NOTICIA oNoticia = null;
        //    try
        //    {
        //        using(MyContext ctx = new MyContext())
        //        {
        //            ctx.Configuration.LazyLoadingEnabled = false;
        //            oNoticia = ctx.NOTICIA.
        //                Where(x => x.ID_NOTICIA == id).
        //                Include("TIPO_NOTICIA").
        //                FirstOrDefault();
        //        }
        //        return oNoticia;
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


        public NOTICIA Save(NOTICIA noticia)
        {
            int retorno = 0;
            NOTICIA oNoticia = null;

            using (MyContext ctx = new MyContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                oNoticia = GetNoticiasById((int)noticia.ID_NOTICIA);

                if (oNoticia == null)
                {
                    //Insertar una nueva Noticia
                    ctx.NOTICIA.Add(noticia);
                    retorno = ctx.SaveChanges();
                }
                else
                {
                    //Actualizar una noticia ya insertada a la DB
                    ctx.NOTICIA.Add(noticia);
                    ctx.Entry(noticia).State = EntityState.Modified;
                    retorno = ctx.SaveChanges();
                }

            }
            return oNoticia;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public NOTICIA GetNoticiasById(int id)
        {
            NOTICIA oNoticia = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    oNoticia = ctx.NOTICIA.
                        Where(x => x.ID_NOTICIA == id).
                        Include("TIPO_NOTICIA").
                        FirstOrDefault();
                }
                return oNoticia;
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