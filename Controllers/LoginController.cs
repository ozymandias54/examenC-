using examenC_.Models;
using examenC_.Repository;
using Microsoft.AspNetCore.Mvc;

namespace examenC_.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(User user)
        {
            UserRepository fr = new UserRepository();
            User u = fr.connexion(user.Login, user.Password);

            if(u != null)
            {
                return RedirectToAction("Index","Home");
            }
            else
            {
                ViewData["erreur"] = "erreur";
            }
            return View();
        }
    }
}
