using examenC_.Models;
using examenC_.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace examenC_.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            FiliereRepository fr=new FiliereRepository();
            ViewData["filieres"] = fr.GetFilieres();

            return View();
        }

        [HttpPost]
        public ActionResult Submit(Filiere filiere)
        {
            if (ModelState.IsValid)
            {
                FiliereRepository fr=new FiliereRepository();
                fr.Ajouter(filiere);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Editer(Filiere filiere)
        {
            FiliereRepository fr = new FiliereRepository();
            fr.Modifier(filiere);
            
            return RedirectToAction("Index");
        }

        public ActionResult Supprimer(int Id)
        {
            FiliereRepository filiereRepository=new FiliereRepository();

            filiereRepository.Supprimer(Id);

            return RedirectToAction("Index");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}