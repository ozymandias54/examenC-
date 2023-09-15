using examenC_.Models;
using examenC_.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace examenC_.Controllers
{
    public class ProfController : Controller
    {
        public IActionResult Index()
        {
            ProfRepository fr = new ProfRepository();
            ViewData["profs"] = fr.GetProfs();

            return View();
        }
        [HttpPost]
        public ActionResult Submit(Prof prof)
        {
            ProfRepository fr = new ProfRepository();
            fr.Ajouter(prof);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Editer(Prof prof)
        {
            ProfRepository fr = new ProfRepository();
            fr.Modifier(prof);

            return RedirectToAction("Index");
        }

        public ActionResult Supprimer(int Id)
        {
            ProfRepository profRepository = new ProfRepository();

            profRepository.Supprimer(Id);

            return RedirectToAction("Index");
        }

    }
}
