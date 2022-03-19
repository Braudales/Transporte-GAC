using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransporteGACweb.BL;

namespace Transporte_GAC.web.Controllers
{
    public class ColaboradorController : Controller
    {
        // GET: Colaborador
        public ActionResult Index()
        {
            var colaboradorBL = new ColaboradorGACBL();
            var listacolaboradores = colaboradorBL.ObtenerColaboradores(); 
            
            return View(listacolaboradores);
        }
    }
}