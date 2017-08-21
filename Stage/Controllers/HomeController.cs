using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stage.Models;
using Stage.ViewModels;
using System.Diagnostics;

namespace Stage.Controllers
{
    public class HomeController : Controller
    {

        private IStageRepository _sc;

        public HomeController(IStageRepository sc)
        {
            _sc = sc;
        }
        public IActionResult Index()
        {
            var data = _sc.getAllFormulairesView();
           
            return View(data);
        }

        
        public IActionResult About()
        {
            ViewData["Message"] = "Your application Login page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public IActionResult DashBord()
        {
            DashBordViewModel dbv = new DashBordViewModel();
            var nbreF = _sc.getFormulairesCount();
            var nbreQ = _sc.getQuestionsCount();
            IEnumerable<Formulaires> FormulairesList = _sc.getAllFormulaires();
            dbv.nbref = nbreF;
            dbv.nbreQ = nbreQ;
            dbv.Formlaires = FormulairesList;
            ViewData["Message"] = "Your application DashBord page.";

            return View(dbv);
        }

        public IActionResult Respance()
        {
            ViewData["Message"] = "Your application Respance page.";
            var data = _sc.getAllFormulaires();
            return View(data);
        }
       
        public IActionResult Formulaire()
        {
            
            ViewData["Message"] = "Your application NewForm page.";

            return View();
        }

       
        public IActionResult Error()
        {
            return View();
        }
    }
}
