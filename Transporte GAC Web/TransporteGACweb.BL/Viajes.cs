using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteGACweb.BL
{
    public class Viajes
    {
        public int Id { get; set; }
        public int ConductorId { get; set; }
        public Conductor Conductor { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }
        public bool Activo { get; set; }
        public List<ControlViajes> ListadeControlViajes { get; set; }

        public Viajes()
        {
            Activo = true;
            Fecha = DateTime.Now;
            ListadeControlViajes = new List<ControlViajes>();
        }
    }
    
    public  class  ControlViajes
    {
        public int Id { get; set; }
        public int ViajesId { get; set; }
        public Viajes Viajes { get; set; }
      

        public int ColaboradorId { get; set; }
        public Colaborador Colaborador { get; set; }
      //  public int SucursalId { get; set; }
      //  public Sucursal Sucursal { get; set; }

        public int cantidad { get; set; }
        public double Precio { get; set; }
        public double Total { get; set; }
    }
}
