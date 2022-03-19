using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteGACweb.BL
{
    public class ColaboradorGACBL
    {
        Contexto _contexto;
        public List<Colaborador> ListadeColaboradores { get; set; }

        public ColaboradorGACBL()
        {
            _contexto = new Contexto();
            ListadeColaboradores = new List<Colaborador>();
        }
        public List<Colaborador> ObtenerColaboradores()
        {
            ListadeColaboradores = _contexto.Colaborador.ToList();
            return ListadeColaboradores;

        }
        public void GuardarColaborador(Colaborador colaborador)
        {
            if (colaborador.Id == 0)
            {
                _contexto.Colaborador.Add(colaborador);
            }
            else
            {
                var colaboradorExistente = _contexto.Colaborador.Find(colaborador.Id);
                colaboradorExistente.Descripcion = colaborador.Descripcion;
                colaboradorExistente.Precio = colaborador.Precio;
            }
          
            _contexto.SaveChanges();
        }

        public Colaborador ObtenerColaborador(int Id)
        {
            var colaborador = _contexto.Colaborador.Find(Id);

            return colaborador;
        }
        
    }
}
