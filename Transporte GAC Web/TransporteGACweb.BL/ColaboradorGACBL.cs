using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteGACweb.BL
{
    public class ColaboradorGACBL
    {
        public List<Colaborador> ObtenerColaboradores()
        {

            var colaborador = new Colaborador();
            colaborador.Id = 1;
            colaborador.Descripcion = "Mario";
            colaborador.Precio = 50;

            var colaborador2 = new Colaborador();
            colaborador2.Id = 2;
            colaborador2.Descripcion = "Carlos";
            colaborador2.Precio = 100;

            var colaborador3 = new Colaborador();
            colaborador3.Id = 3;
            colaborador3.Descripcion = "Brayan";
            colaborador3.Precio = 200;

            var listacolaboradores = new List<Colaborador>();
            listacolaboradores.Add(colaborador);
            listacolaboradores.Add(colaborador2);
            listacolaboradores.Add(colaborador3);

            return listacolaboradores;
        }
    }
}
