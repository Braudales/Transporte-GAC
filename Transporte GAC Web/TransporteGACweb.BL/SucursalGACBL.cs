using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransporteGACweb.BL;

namespace TransporteGACweb.BL
{
    public class SucursalGACBL
    {
        Contexto _contexto;
        public List<Sucursal> ListadeSucursales { get; set; }

        public SucursalGACBL()
        {
            _contexto = new Contexto();
            ListadeSucursales = new List<Sucursal>();
        }
        public List<Sucursal> Obtenersucursales()
        {
            ListadeSucursales = _contexto.Sucursal.ToList();
            return ListadeSucursales;

        }
        public void GuardarSucursal(Sucursal sucursal)
        {
            if (sucursal.Id == 0)
            {
                _contexto.Sucursal.Add(sucursal);
            }
            else
            {
                var sucursalExistente = _contexto.Sucursal.Find(sucursal.Id);
                sucursalExistente.Nombre = sucursal.Nombre;
                sucursalExistente.telefono = sucursal.telefono;
            }

            _contexto.SaveChanges();
        }

        public Sucursal Obtenersucursal(int Id)
        {
            var sucursal = _contexto.Sucursal.Find(Id);

            return sucursal;
        }

        public Sucursal EliminarSucursal(int Id)
        {
            var sucursal = _contexto.Sucursal.Find(Id);
            _contexto.Sucursal.Remove(sucursal);
            _contexto.SaveChanges();

            return sucursal;

        }
    }
}