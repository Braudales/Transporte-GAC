using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransporteGACweb.BL;

namespace TransporteGAC.webadmin.Controllers
{
    public class SucursalController : Controller
    {
        SucursalGACBL _sucursalBL;

        public SucursalController()
        {
            _sucursalBL = new SucursalGACBL();
        }

        // GET: Sucursal
        public ActionResult Index()
        {

            var ListadeSucursales = _sucursalBL.Obtenersucursales();
            return View(ListadeSucursales);
        }

        public ActionResult Crear()
        {
            var nuevaSucursal = new Sucursal();
            return View(nuevaSucursal);
        }

        [HttpPost]
        public ActionResult Crear(Sucursal sucursal)
        {
            if (ModelState.IsValid)
            {
                _sucursalBL.GuardarSucursal(sucursal);
                return RedirectToAction("Index");
            }
            return View(sucursal);
        }

        public ActionResult Editar(int Id)
        {
            var sucursal = _sucursalBL.Obtenersucursal(Id);
            return View(sucursal);
        }

        [HttpPost]
        public ActionResult Editar(Sucursal sucursal)
        {
            _sucursalBL.GuardarSucursal(sucursal);
            return RedirectToAction("Index");
        }

        public ActionResult Detalle(int Id)
        {
            var sucursal = _sucursalBL.Obtenersucursal(Id);
            return View(sucursal);
        }


        public ActionResult Eliminar(int Id)
        {
            var sucursal = _sucursalBL.Obtenersucursal(Id);
            return View(sucursal);
        }

        [HttpPost]
        public ActionResult Eliminar(Sucursal sucursal)
        {
            _sucursalBL.EliminarSucursal(sucursal.Id);
            return RedirectToAction("Index");
        }
    }
}