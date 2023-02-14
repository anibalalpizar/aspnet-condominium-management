using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Model
{
    internal partial class TIPO_NOTICIAMetadata
    {
        public int ID_TIPO_NOTICIA { get; set; }
        
        [Display(Name = "Nombre")]
        public string TIPO_NOTICIA { get; set; }

        public virtual ICollection<NOTICIA> NOTICIAs { get; set; }
    }
}
