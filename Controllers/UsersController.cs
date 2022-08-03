using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnboardingDervico.Models;

namespace OnboardingDervico.Controllers
{
    [Authorize]
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
        public IActionResult EditOnboardUser(useronboard user , int ? val )
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

            if(val == 1)
            {
                




            }

            _dervicoDbContext.SaveChanges();
            return RedirectToAction("DashBoard","Home");
        }
        public IActionResult DetailsOnboardUser(string id)
        {
            useronboard exist = _dervicoDbContext.useronboard.Where(p => p.empId == id).FirstOrDefault();


            return View(exist);
        }

        public IActionResult DeleteOnboardUser(string id)
        {

            var query = _dervicoDbContext.useronboard.Where(p => p.empId == id).FirstOrDefault();

            _dervicoDbContext.useronboard.Remove(query);


            if(query != null)
            {
                var s = _dervicoDbContext.users.Where(p => p.staffId == id).FirstOrDefault();
                if (s != null) {
                    s.lockcount = 0;
                        }
                _dervicoDbContext.SaveChanges();

                
            }
            _dervicoDbContext.SaveChanges();
            return RedirectToAction("DashBoard", "Home");
        }

        public IActionResult StatusUpdate(string id)
        {
          var user= _dervicoDbContext.userProfile.Where(p=>p.staffId == id).FirstOrDefault();



            return View (user);
        }
        [HttpPost]
        public IActionResult StatusUpdate(UserProfile user)
        {
            var val = _dervicoDbContext.userProfile.Where(p => p.staffId == user.staffId).FirstOrDefault();

            if(val != null)
            {
                val.startDate = user.startDate;
                val.Status = user.Status;

                _dervicoDbContext.SaveChanges();

            }
            return RedirectToAction("DashBoard","Home");
        }


    }
}
