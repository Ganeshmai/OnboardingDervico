using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnboardingDervico.Models;
using System.Net.Mail;
using System.Text;

namespace OnboardingDervico.Controllers
{
  //  [Authorize]
    public class Onboard : Controller
    {
        private readonly DervicoDbContext _dervicoDbContext;

        public Onboard(DervicoDbContext dervicoDbContext)
        {
            _dervicoDbContext = dervicoDbContext;
        }

        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(useronboard Users)
        {
            if (ModelState.IsValid) 
                if (Users != null )
                {

                    _dervicoDbContext.useronboard.Add(Users);


                   var res=  SendMailToHtmPmo(Users);


                    if (res == true)
                    {
                        TempData["Message"] = "Saved Sucessfully - Mail Sended";
                    }

                    _dervicoDbContext.SaveChanges();

                    ModelState.Clear();
                }

           

            return View("AddUser");
        }

        public bool SendMailToHtmPmo( useronboard user )
        {
            bool status = false;

           
            try
            {
               
                string to = "maiganesh2000@gmail.com"; //To address    
                string from = "maiganesh2000@gmail.com"; //From address    
                MailMessage message = new MailMessage(from, to);

                string textBody = " <table border=" + 1 + " cellpadding=" + 0 + " cellspacing=" + 0 + " width = " + 700 + "height=" + 500 + "><tr bgcolor='#4da6ff'><td><b>Emp Id</b></td> <td> <b> Name</b> </td><td> <b> SurName</b> </td><td> <b> Email Id</b> </td><td> <b> Business Unit</b> </td><td> <b> Department</b> </td><td> <b> Team</b> </td><td> <b> SubTeam</b> </td><td> <b> Position</b> </td> <td> <b> Job Profile</b> </td><td> <b> Location</b> </td><td> <b> Derivco Manager</b> </td><td> <b> Hire Date</b> </td> <td> <b> Cost Centre </b> </td> <td> <b> Gender</b> </td></tr>";
                textBody += "<tr><td>" + user.empId+ "</td> <td>" + user.name + "</td><td>" + user.surname + "</td> <td>" + user.emailId + "</td> <td>" + user.businessUnit + "</td> <td>" + user.department + "</td> <td>" + user.team + "</td> <td>" + user.subTeam + "</td> <td>" + user.position + "</td> <td>" + user.jobProfile + "</td> <td>" + user.location + "</td> <td>" + user.derivcoManager + "</td><td>" + user.startDate + "</td><td>" + user.costCentre + "</td><td>" + user.gender + "</td> </tr>";
                
                textBody += "</table>";


                
                message.Subject = "Sending Email Using Asp.Net & C#";
                message.Body = textBody;
                message.BodyEncoding = Encoding.UTF8;
                message.IsBodyHtml = true;
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
                System.Net.NetworkCredential basicCredential1 = new
                System.Net.NetworkCredential("maiganesh2000@gmail.com", "lyudqawhypmjulug");
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = basicCredential1;
                client.Send(message);
               status= true;
            }
            catch (Exception ex)
            {
                var val = ex.Message;
                status = false;
            }

            return  status;

        }

         
        
    }
}
