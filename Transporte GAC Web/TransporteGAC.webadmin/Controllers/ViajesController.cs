using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransporteGACweb.BL;

namespace TransporteGAC.webadmin.Controllers
{

    public class ViajesController : Controller
    {
        ViajesBL _viajesBl;
        ConductorBL _conductorbl;
        public ViajesController()
        {
            _viajesBl = new ViajesBL();
            _conductorbl = new ConductorBL();
        }
    
        // GET: Viajes
        public ActionResult Index()
        {
            var listadeViajes = _viajesBl.Obtenerviajes();
            return View(listadeViajes);
        }
        public ActionResult Crear()
        {
            var nuevoviaje = new Viajes();
            var conductor = _conductorbl.ObtenerConductores();
            ViewBag.conductorId = new SelectList(conductor, "Id", "Nombre");
            return View(nuevoviaje);
        }

        [HttpPost]
        public ActionResult Crear(Viajes viajes)
        {
            if (ModelState.IsValid)
            {
                if (viajes.ConductorId == 0)
                {
                    ModelState.AddModelError("ConductorId", "Selecciones un conductor");
                    return View(viajes);

                }
                _viajesBl.GuardarViajes(viajes);
                return RedirectToAction("Index");
            }
            var conductor = _conductorbl.ObtenerConductores();
            ViewBag.conductorId = new SelectList(conductor, "Id", "Nombre");
            return View(viajes);
            
        }
        public ActionResult Editar(int id)
        {
            var viaje = _viajesBl.Obtenerviaje(id);
            var conductor = _conductorbl.ObtenerConductores();
            
            ViewBag.conductorId = new SelectList(conductor, "Id", "Nombre", viaje.ConductorId);
            return View(viaje);
        }

        [HttpPost]
        public ActionResult Editar(Viajes viajes)
        {
            if (ModelState.IsValid)
            {
                if (viajes.ConductorId == 0)
                {
                    ModelState.AddModelError("ConductorId", "Selecciones un conductor");
                    return View(viajes);

                }
                _viajesBl.GuardarViajes(viajes);
                return RedirectToAction("Index");
            }
            var conductor = _conductorbl.ObtenerConductores();
            ViewBag.conductorId = new SelectList(conductor, "Id", "Nombre", viajes.ConductorId);
            return View(viajes);

        }
        public ActionResult Detalle(int id)
        {
            var viaje = _viajesBl.Obtenerviaje(id);
            return View(viaje);
        }

    }
}