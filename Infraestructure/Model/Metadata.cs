using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Model
{
    internal partial class GESTION_PLANES_COBROMetadata
    {


        [Display(Name = "La descripciíon")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public string DESCRIPCION { get; set; }

    }

    internal partial class INCIDENCIAMetadata
    {
        [Display(Name = "Id Autor")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public int ID_USUARIO { get; set; }
        [Display(Name = "El titulo")]
        [Required(ErrorMessage = "{0} es un dato requerido")]

        public string DESCRIPCION { get; set; }



    }




    internal partial class NOTICIAMetadata
    {
        [Display(Name = "El título")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public string TITULO { get; set; }
        [Display(Name = "El contenido")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public string CONTENIDO { get; set; }
        public System.DateTime FECHA_PUBLICACION { get; set; }


    }
    internal partial class RUBRO_COBROMetadata
    {
        [Display(Name = "La descripción")]

        [Required(ErrorMessage = "{0} es un dato requerido")]
        public string DESCRIPCION { get; set; }

        [Display(Name = "El monto")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [RegularExpression(@"^[0-9]+(\.[0-9]{1,2})?$", ErrorMessage = "solo acepta números, con dos decimales")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public Nullable<decimal> MONTO { get; set; }


    }







}