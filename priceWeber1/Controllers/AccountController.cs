using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using priceWeber1.Models;
using System.Net.Mail;
using System.Threading.Tasks;


namespace priceWeber1.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
               public ActionResult Register()
        {
            return View();
        }
        [HttpPost]

        public async Task<ActionResult> Register(UserAccount account)
        {
            if (ModelState.IsValid)
            {
                //use these for IP and date time
                account.MyIPAddress = Request.UserHostAddress; //more ip checks are needed
                DateTime time = DateTime.Now;                  // Use current time.
                account.MyDateTime = time.ToString();

                using (OurDBContext db = new OurDBContext())
                {
                    db.userAccount.Add(account);
                    db.SaveChanges();

                   await SendAsyncMail(account.FirstName, account.LastName, account.Email);
                   await WriteExcel(account.MyIPAddress, account.FirstName, account.LastName, account.Email);

                }
                ModelState.Clear();
               
               ViewBag.Message =  account.FirstName + " " + account.LastName + " successfully registered.";
               

            }
            else { ViewBag.Message = "Unable to create."; }
            return View();
        }
       
        public ActionResult ShowDB()
        {
            using (OurDBContext db = new OurDBContext())
            {
                return View(db.userAccount.ToList());
            }
                
        }
        public async static Task SendAsyncMail(string fname, string lname, string UserEmail)
        {
            await Task.Delay(18); //this line is here to check the flow of code

            //un comment this block to actually send an email. The code below needs tweaks to actually send.
            //await Task.Delay(1800000);
            //var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
            //var message = new MailMessage();
            //message.To.Add(new MailAddress(UserEmail));  // replace with valid value 
            //message.From = new MailAddress("sender@outlook.com");  // replace with valid value
            //message.Subject = "Thanks for Signing Up!";
            //message.Body = string.Format(body, "PriceWeber", "priceWeber1@gmail.com", "Thanks for signing up. We appreciate your business.");
            //message.IsBodyHtml = true;

            //using (var smtp = new SmtpClient())
            //{
            //    var credential = new NetworkCredential
            //    {
            //        UserName = "user@gmail.com",  // replace with valid value
            //        Password = "password"  // replace with valid value
            //    };
            //    smtp.Credentials = credential;
            //    smtp.Host = " 	smtp.gmail.com";
            //    smtp.Port = 587;
            //    smtp.EnableSsl = true;
            //    await smtp.SendMailAsync(message);

        }
      
         public async static Task WriteExcel(string fname, string lname, string aemail, string aip)
        {
        await Task.Delay(18);
        }

    }
}