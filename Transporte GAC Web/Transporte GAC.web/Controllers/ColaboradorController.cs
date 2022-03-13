using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transporte_GAC.web.Models;

namespace Transporte_GAC.web.Controllers
{
    public class ColaboradorController : Controller
    {
        // GET: Colaborador
        public ActionResult Index()
        {
            var colaborador = new ColaboradorModel();
            colaborador.Id = 1;
            colaborador.Descripcion = "Mario";

            var colaborador2 = new ColaboradorModel();
            colaborador2.Id = 2;
            colaborador2.Descripcion = "Carlos";

            var colaborador3 = new ColaboradorModel();
            colaborador3.Id = 3;
            colaborador3.Descripcion = "Brayan";

            var listacolaboradores = new List<ColaboradorModel>();
            listacolaboradores.Add(colaborador);
            listacolaboradores.Add(colaborador2);
            listacolaboradores.Add(colaborador3);
            return View(listacolaboradores);
        }
    }
}