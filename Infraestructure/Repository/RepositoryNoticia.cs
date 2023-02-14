using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class RepositoryNoticia : IRepositoryNoticia
    {
        public IEnumerable<NOTICIA> GetNoticias()
        {
            try
            {
                IEnumerable<NOTICIA> lista = null;
                using(MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    //lista = ctx.NOTICIAs.ToList<NOTICIA>();

                    // obtener todos las noticias incluyendo el tipo de noticia (Anuncio o Noticia)
                    lista = ctx.NOTICIAs.Include(x => x.TIPO_NOTICIA1).ToList();

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