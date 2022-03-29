using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteGACweb.BL
{
   public class ViajesBL
    {
        Contexto _contexto;
        public List<Viajes> ListadeViajes { get; set; }

        public ViajesBL()
        {
            _contexto = new Contexto();
            ListadeViajes = new List<Viajes>();
        }
        public List<Viajes> Obtenerviajes()
        {
            ListadeViajes = _contexto.Viajes
                .Include("Conductor")
                .ToList();
            return ListadeViajes;

        }

        public List<ControlViajes> ObtenerControldeviajes(int viajeId)
        {
            var ListadeControldeviajes = _contexto.ControlViajes.Include("Colaborador").Include("Sucursal").Include("Tipo").
                   Where(o => o.ViajesId== viajeId ).
                 ToList();
            return ListadeControldeviajes;

        }

        public void GuardarViajes(Viajes viajes)
        {
            _contexto.Viajes.Add(viajes);
            _contexto.SaveChanges();
        }

        public Viajes Obtenerviaje(int id)
        {
            var viaje = _contexto.Viajes
                .Include("Conductor").FirstOrDefault(p => p.Id == id);

            return viaje;
        }

        public void GuardarViaje(Viajes viaje)
        {
            if (viaje.Id == 0)
            {
                _contexto.Viajes.Add(viaje);
            }
            else
            {
                var viajeExistente = _contexto.Viajes.Find(viaje.Id);
              
                viajeExistente.ConductorId = viaje.ConductorId;
                viajeExistente.Activo = viaje.Activo;
            }

            _contexto.SaveChanges();
        }

        public void GuardarControlviajes(ControlViajes controlviajes)
        {
            var colaborador = _contexto.Colaborador.Find(controlviajes.ColaboradorId);
            colaborador.SucursalId = colaborador.SucursalId;
            colaborador.TipoId = colaborador.TipoId;
            controlviajes.Precio = colaborador.Precio;
            controlviajes.Total = controlviajes.cantidad * controlviajes.Precio;
            _contexto.ControlViajes.Add(controlviajes);
            var viaje = _contexto.Viajes.Find(controlviajes.ViajesId);
            viaje.Total = viaje.Total + controlviajes.Total;
           
            _contexto.SaveChanges();
        }
    }
}
