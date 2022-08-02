using Microsoft.AspNetCore.Mvc;
using OnboardingDervico.Models;

namespace OnboardingDervico.Controllers
{
    public class UsersController : Controller
    {
        private readonly DervicoDbContext _dervicoDbContext;

        public UsersController(DervicoDbContext dervicoDbContext)
        {
            _dervicoDbContext = dervicoDbContext;
        }
        public IActionResult Details()
        {
            List<useronboard> users = _dervicoDbContext.useronboard.ToList();

            return View(users);
        }
        public IActionResult EditOnboardUser(string id)
        {
            useronboard user = _dervicoDbContext.useronboard.Where(p => p.empId == id).FirstOrDefault();
            return View(user);
        }
        [HttpPost]
        public IActionResult EditOnboardUser(useronboard user)
        {
            useronboard exist = _dervicoDbContext.useronboard.Where(p => p.empId == user.empId).FirstOrDefault();
            if (exist != null)
                exist.empId = user.empId;
            exist.emailId = user.emailId;
            exist.costCentre = user.costCentre;
            exist.position = user.position;
            exist.startDate = user.startDate;
            exist.derivcoManager = user.derivcoManager;
            exist.businessUnit = user.businessUnit;
            exist.department = user.department;
            exist.gender = user.gender;
            exist.jobProfile = user.jobProfile;
            exist.name = user.name;
            exist.subTeam = user.subTeam;
            exist.surname = user.surname;
            exist.team = user.team;

            _dervicoDbContext.SaveChanges();
            return View("DashBoard");
        }
        public IActionResult DetailsOnboardUser(string id)
        {
            useronboard exist = _dervicoDbContext.useronboard.Where(p => p.empId == id).FirstOrDefault();


            return View(exist);
        }
    }
}
