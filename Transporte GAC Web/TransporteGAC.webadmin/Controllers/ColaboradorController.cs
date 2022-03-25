using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransporteGACweb.BL;

namespace TransporteGAC.webadmin.Controllers
{
    public class ColaboradorController : Controller
    {
        ColaboradorGACBL _colaboradorBL;
        SucursalGACBL _sucursalBL;
        TipoBL _tipoBl;
        public ColaboradorController()
        {
            _colaboradorBL = new ColaboradorGACBL();
            _sucursalBL = new SucursalGACBL();
            _tipoBl = new TipoBL();
        }
        // GET: Colaborador
        public ActionResult Index()
        {
            var ListadeColaboradores = _colaboradorBL.ObtenerColaboradores();
            
            return View(ListadeColaboradores);
        }
        
        public ActionResult Crear()
        {
            var nuevoColaborador = new Colaborador();
            var Sucursales = _sucursalBL.Obtenersucursales();
            var Tipo = _tipoBl.ObtenerTipos();
            ViewBag.SucursalId
                     = new SelectList(Sucursales, "Id", "Nombre");
            ViewBag.TipoId
                     = new SelectList(Tipo, "Id", "Departamento");

            return View(nuevoColaborador);
        }

        [HttpPost]
        public ActionResult Crear(Colaborador colaborador)
        {
            _colaboradorBL.GuardarColaborador(colaborador);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            var colaborador = _colaboradorBL.ObtenerColaborador(id);
            var Sucursales = _sucursalBL.Obtenersucursales();
            var Tipo = _tipoBl.ObtenerTipos();
           ViewBag.SucursalId = 
                new SelectList(Sucursales, "Id", "Nombre", colaborador.SucursalId);
            ViewBag.TipoId =
                new SelectList(Tipo, "Id", "Departamento", colaborador.TipoId);
            return View(colaborador);
        }
       

        [HttpPost]
        public ActionResult Editar(Colaborador colaborador)
        {
            _colaboradorBL.GuardarColaborador(colaborador);
            return RedirectToAction("Index");
        }

        public ActionResult Detalle(int Id)
        {
            var colaborador = _colaboradorBL.ObtenerColaborador(Id);
            return View(colaborador);
        }


        public ActionResult Eliminar(int Id)
        {
            var colaborador = _colaboradorBL.ObtenerColaborador(Id);
            return View(colaborador);
        }

        [HttpPost]
        public ActionResult Eliminar(Colaborador colaborador)
        {
            _colaboradorBL.EliminarColaborador(colaborador.Id);
            return RedirectToAction("Index");
        }

    }
}