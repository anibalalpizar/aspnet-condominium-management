using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Model
{
    internal partial class LibroMetadata

    {

        public string NOMBRE_RUBRO { get; set; }

        [Required(ErrorMessage = "{0} es un dato requerido")]
        public string Isbn { get; set; }


    }
}