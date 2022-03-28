using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteGACweb.BL
{

    public class Colaborador
    {
        public Colaborador()
        {
            Activo = true;
        }
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public Sucursal Sucursal { get; set; }
        public int SucursalId { get; set; }
        public Tipo Tipo { get; set; }
        public int TipoId { get; set; }
        [Display(Name = "Imagen")]
        public string UrlImagen { get; set; }
        public bool Activo { get; set; }



    }
}
