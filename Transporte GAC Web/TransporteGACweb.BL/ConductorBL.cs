using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteGACweb.BL
{
   public class ConductorBL
    {
        Contexto _contexto;
        public List<Conductor> ListadeConductores { get; set; }

        public ConductorBL()
        {
            _contexto = new Contexto();
            ListadeConductores = new List<Conductor>();
        }
        public List<Conductor> ObtenerConductores()
        {
            ListadeConductores = _contexto.Conductor.ToList();
            return ListadeConductores;

        }
        public void GuardarConductor(Conductor conductor)
        {
            if (conductor.Id == 0)
            {
                _contexto.Conductor.Add(conductor);
            }
            else
            {
                var conductorExistente = _contexto.Conductor.Find(conductor.Id);
                conductorExistente.Nombre = conductor.Nombre;
                conductorExistente.telefono = conductor.telefono;
                conductorExistente.Activo = conductor.Activo;

            }

            _contexto.SaveChanges();
        }

        public Conductor Obtenerconductor(int Id)
        {
            var conductor = _contexto.Conductor.Find(Id);

            return conductor;
        }

        public Conductor Eliminarconductor(int Id)
        {
            var conductor = _contexto.Conductor.Find(Id);
            _contexto.Conductor.Remove(conductor);
            _contexto.SaveChanges();

            return conductor;

        }
    }
}
