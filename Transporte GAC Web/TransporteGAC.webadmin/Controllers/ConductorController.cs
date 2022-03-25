using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransporteGACweb.BL;

namespace TransporteGAC.webadmin.Controllers
{
    public class ConductorController : Controller
    {
        ConductorBL _conductorBL;

        public ConductorController()
        {
            _conductorBL = new ConductorBL();
        }
        // GET: Conductor
        public ActionResult Index()
        {

            var ListadeConductor = _conductorBL.ObtenerConductores();
            return View(ListadeConductor);
        }

        public ActionResult Crear()
        {
            var nuevoConductor = new Conductor();
            return View(nuevoConductor);
        }

        [HttpPost]
        public ActionResult Crear(Conductor Conductor)
        {
            if (ModelState.IsValid)
            {
                _conductorBL.GuardarConductor(Conductor);
                return RedirectToAction("Index");
            }
            return View(Conductor);
        }

        public ActionResult Editar(int Id)
        {
            var conductor = _conductorBL.Obtenerconductor(Id);
            return View(conductor);
        }

        [HttpPost]
        public ActionResult Editar(Conductor conductor)
        {
            _conductorBL.GuardarConductor(conductor);
            return RedirectToAction("Index");
        }

        public ActionResult Detalle(int Id)
        {
            var conductor = _conductorBL.Obtenerconductor(Id);
            return View(conductor);
        }


        public ActionResult Eliminar(int Id)
        {
            var conductor = _conductorBL.Obtenerconductor(Id);
            return View(conductor);
        }

        [HttpPost]
        public ActionResult Eliminar(Conductor conductor)
        {
            _conductorBL.Eliminarconductor(conductor.Id);
            return RedirectToAction("Index");
        }
    }
}
