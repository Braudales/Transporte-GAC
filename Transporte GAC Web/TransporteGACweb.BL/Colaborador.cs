using System;
using System.Collections.Generic;
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
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public Sucursal Sucursal { get; set; }
        public int SucursalId { get; set; }
        public bool Activo { get; set; }

    }
}
