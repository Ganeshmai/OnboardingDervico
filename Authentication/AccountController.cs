using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnboardingDervico.Models;
using System.Security.Claims;

namespace OnboardingDervico.Authentication
{
    public class AccountController : Controller
    {

        private readonly DervicoDbContext _dbContext;

        public AccountController(DervicoDbContext  dbContext)
        {
            _dbContext = dbContext;
        }

     
        public IActionResult Login(string returnUrl)
        
        {
            ViewData["ReturnUrl"] = returnUrl;
          
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> Login(users Users ,string returnUrl)
        {
            ViewData["ReturnUrl"]= returnUrl;
            
                users Data = _dbContext.users.FirstOrDefault(a => a.staffId == Users.staffId && a.password == Users.password);

                if (Data != null)
                {
                    users check = _dbContext.users.FirstOrDefault(a => a.staffId == Users.staffId && a.lockcount == 1 && a.roleId >= 1);
                    if (check != null)
                    {
                    HttpContext.Session.SetString("userId",check.staffId);
                    HttpContext.Session.SetString("User",check.fullName);
                    HttpContext.Session.SetString("UserEmail",check.emailId );


                    var claims = new List<Claim>() {
                       new Claim("username",check.staffId),
                       new Claim(ClaimTypes.Role,check.roleId.ToString()),
                       new Claim(ClaimTypes.Email,check.emailId) };
                    
                    var claimIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);

                    if(returnUrl == null)
                    {
                        return RedirectToAction("DashBoard", "Home");
                    }

                        return Redirect(returnUrl);

                       
                    }
                    else
                    {
                        TempData["Message"] = "The User is Inactive ";
                    }
                }
                else
                {
                    TempData["Message"] = "UserName or Password Incorrect";


                }
            
            
            return View("Login");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return View("Login");
        }

        public async Task<IActionResult> AccessDenied()
        {
            return View();
        }
    }
}
