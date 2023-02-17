using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Web;
using Infraestructure.Model;

namespace Infraestructure.Repository
{
    public class RepositoryNoticia : IRepositoryNoticia
    {
        public IEnumerable<NOTICIA> GetNoticias()
        {
            try
            {
                IEnumerable<NOTICIA> lista = null;
                using(CONDOMINIOSEntities ctx = new CONDOMINIOSEntities())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    //lista = ctx.NOTICIAs.ToList<NOTICIA>();

                    // obtener todos las noticias incluyendo el tipo de noticia (Anuncio o Noticia)
                    lista = ctx.NOTICIA.Include(x => x.TIPO_NOTICIA).ToList();

                }
                return lista;
            }
            catch
            {
                throw;
            }
        }
    }
}