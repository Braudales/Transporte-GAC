using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransporteGACweb.BL;

namespace TransporteGAC.webadmin.Controllers
{
    public class ControldeViajesController : Controller
     
    {
        ViajesBL _viajesBl;
        ColaboradorGACBL _colaboradorBl;
        SucursalGACBL _sucursalBL;
        TipoBL _Tiposbl;
       
        public ControldeViajesController()
        {
            _viajesBl = new ViajesBL();
            _colaboradorBl = new ColaboradorGACBL();
            _sucursalBL = new SucursalGACBL();
            _Tiposbl = new TipoBL();
        }

        // GET: ControldeViajes
        public ActionResult Index(int id)
        {
            var controldeViajes = _viajesBl.Obtenerviaje(id);
            controldeViajes.ListadeControlViajes = _viajesBl.ObtenerControldeviajes(id);

            return View(controldeViajes);
        }

        public ActionResult Crear(int id)
        {
            var nuevocontrolviaje = new ControlViajes();
            nuevocontrolviaje.ViajesId = id;

            var colaboradores = _colaboradorBl.ObtenerColaboradores();
            ViewBag.ColaboradorId = new SelectList(colaboradores, "Id","Descripcion");

            var sucursales = _sucursalBL.Obtenersucursales();
            ViewBag.SucursalId = new SelectList(sucursales, "Id", "Nombre");

            var tipos = _Tiposbl.ObtenerTipos();
            ViewBag.TipoId = new SelectList(tipos, "Id", "Departamento");

            //
            return View(nuevocontrolviaje);
        }

        [HttpPost]
        public ActionResult Crear(ControlViajes controlviajes)
        {
            if (ModelState.IsValid)
            {
                if (controlviajes.ColaboradorId == 0)
                {
                    ModelState.AddModelError("ColaboradorId", "Selecciones un colaborador");
                    return View(controlviajes);

                }
                _viajesBl.GuardarControlviajes(controlviajes);
                return RedirectToAction("Index", new {id = controlviajes.ViajesId });
            }
            var colaborador = _colaboradorBl.ObtenerColaboradores();
            ViewBag.colaboradorId = new SelectList(colaborador, "Id", "Descripcion");

            var sucursales = _sucursalBL.Obtenersucursales();
            ViewBag.SucursalId = new SelectList(sucursales, "Id", "Nombre");

             var tipos = _Tiposbl.ObtenerTipos();
            ViewBag.TipoId = new SelectList(tipos, "Id", "Departamento");
            return View(controlviajes);

        }
    }
}