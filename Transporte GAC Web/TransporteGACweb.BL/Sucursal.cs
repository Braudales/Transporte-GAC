using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteGACweb.BL
{
    public class Sucursal
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Ingrese el nombre de la sucursal")]
        public string Nombre { get; set; }
        public string telefono { get; set; }
      
    }
}
