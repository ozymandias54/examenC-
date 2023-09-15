using examenC_.Models;
using examenC_.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace examenC_.Controllers
{
    public class CoursController : Controller
    {
        private readonly ILogger<CoursController> _logger;

        public CoursController(ILogger<CoursController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            CoursRepository fr=new CoursRepository();
            ViewData["cours"] = fr.GetCourss();

            return View();
        }

        [HttpPost]
        public ActionResult Submit(Cours cours)
        {
            if (ModelState.IsValid)
            {
                CoursRepository fr=new CoursRepository();
                fr.Ajouter(cours);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Editer(Cours cours)
        {
            CoursRepository fr = new CoursRepository();
            fr.Modifier(cours);
            
            return RedirectToAction("Index");
        }

        public ActionResult Supprimer(int Id)
        {
            CoursRepository coursRepository=new CoursRepository();

            coursRepository.Supprimer(Id);

            return RedirectToAction("Index");
        }


    }
}