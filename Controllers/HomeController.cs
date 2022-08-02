using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnboardingDervico.Models;
using System.Diagnostics;

namespace OnboardingDervico.Controllers
{
//[Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly DervicoDbContext _dervicoDbContext;


        public HomeController(ILogger<HomeController> logger, DervicoDbContext dervicoDbContext)
        {
            _logger = logger;
            _dervicoDbContext = dervicoDbContext;
        }


        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles ="1")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       
        [Route("")]
        [Route("/Dashboard")]
        public IActionResult DashBoard()
        {
            var users = _dervicoDbContext.useronboard;

            return View(users);
        }


    }
}