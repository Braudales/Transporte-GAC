using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteGACweb.BL
{
    public class TipoBL
    {
        Contexto _contexto;
        public List<Tipo> ListadeTipo { get; set; }

        public TipoBL()
        {
            _contexto = new Contexto();
            ListadeTipo = new List<Tipo>();
        }
        public List<Tipo> ObtenerTipos()
        {
            ListadeTipo = _contexto.Tipo.ToList();
            return ListadeTipo;

        }
        public void GuardarTipo(Tipo tipo)
        {
            if (tipo.Id == 0)
            {
                _contexto.Tipo.Add(tipo);
            }
            else
            {
                var sucursalExistente = _contexto.Tipo.Find(tipo.Id);
                sucursalExistente.Departamento = tipo.Departamento;
           
            }

            _contexto.SaveChanges();
        }

        public Tipo ObtenerTipo(int Id)
        {
            var tipo = _contexto.Tipo.Find(Id);

            return tipo;
        }

        public Tipo EliminarTipo(int Id)
        {
            var tipo = _contexto.Tipo.Find(Id);
            _contexto.Tipo.Remove(tipo);
            _contexto.SaveChanges();

            return tipo;

        }
    }
}
