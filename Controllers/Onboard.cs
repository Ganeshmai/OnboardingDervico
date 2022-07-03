using Microsoft.AspNetCore.Mvc;
using OnboardingDervico.Models;

namespace OnboardingDervico.Controllers
{
    public class Onboard : Controller
    {
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(users users)
        {
            return View(users);
        }
    }
}
