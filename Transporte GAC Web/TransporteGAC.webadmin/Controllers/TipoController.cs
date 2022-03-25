using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransporteGACweb.BL;

namespace TransporteGAC.webadmin.Controllers
{
    public class TipoController : Controller
    {
        TipoBL _tipoBL;

        public TipoController()
        {
            _tipoBL = new TipoBL();
        }
        // GET: Tipo
        public ActionResult Index()
        {

            var ListadeTipo = _tipoBL.ObtenerTipos();
            return View(ListadeTipo);
        }

        public ActionResult Crear()
        {
            var nuevodepartamento = new Tipo();
            return View(nuevodepartamento);
        }

        [HttpPost]
        public ActionResult Crear(Tipo tipo)
        {
            if (ModelState.IsValid)
            {
                _tipoBL.GuardarTipo(tipo);
                return RedirectToAction("Index");
            }
            return View(tipo);
        }

        public ActionResult Editar(int Id)
        {
            var tipo = _tipoBL.ObtenerTipo(Id);
            return View(tipo);
        }

        [HttpPost]
        public ActionResult Editar(Tipo tipo)
        {
            _tipoBL.GuardarTipo(tipo);
            return RedirectToAction("Index");
        }

        public ActionResult Detalle(int Id)
        {
            var tipo = _tipoBL.ObtenerTipo(Id);
            return View(tipo);
        }


        public ActionResult Eliminar(int Id)
        {
            var tipo = _tipoBL.ObtenerTipo(Id);
            return View(tipo);
        }

        [HttpPost]
        public ActionResult Eliminar(Tipo tipo)
        {
            _tipoBL.EliminarTipo(tipo.Id);
            return RedirectToAction("Index");
        }
    }
}