using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class RepositoryUsuario : IRepositoryUsuario
    {
        public USUARIO GetUsuario(string email, string password)
        {
            USUARIO oUsuario = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    oUsuario = ctx.USUARIO.Where(p => p.CORREO.Equals(email) && p.CONTRASENA == password).
                        FirstOrDefault<USUARIO>();
                }
                if (oUsuario != null)
                    oUsuario = GetUsuarioById(oUsuario.ID_USUARIO);
                return oUsuario;
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

        public USUARIO GetUsuarioById(int id)
        {
            USUARIO usu = null;
            try
            {

                using (MyContext ctx = new MyContext())
                {
                    usu = ctx.USUARIO.Where(u => u.ID_USUARIO == id).Include("TIPO_USUARIO").Include("ESTADO_USUARIO").FirstOrDefault();
                }
                return usu;
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

        public IEnumerable<USUARIO> GetUSUARIOs()
        {
            try
            {
                List<USUARIO> list = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    list = ctx.USUARIO.Include(x => x.ESTADO_USUARIO).Include(x => x.TIPO_USUARIO).ToList<USUARIO>();
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

        public USUARIO Save(USUARIO usuario)
        {
            try
            {
                USUARIO oUsu = null;
                int retorno = 0;

                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    oUsu = GetUsuarioById(usuario.ID_USUARIO);
                    if (oUsu == null)
                    {
                        //Insertar un nuevo Usuario
                        ctx.USUARIO.Add(usuario);
                        retorno = ctx.SaveChanges();
                    }
                    else
                    {
                        //Actualizar Usuario
                        ctx.USUARIO.Add(usuario);
                        ctx.Entry(usuario).State = EntityState.Modified;
                        retorno = ctx.SaveChanges();
                    }
                }

                if (retorno > 0)
                    oUsu = GetUsuarioById((int)usuario.ID_USUARIO);
                return oUsu;
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
