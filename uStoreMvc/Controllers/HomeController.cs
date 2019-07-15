using System.Net;
using System.Net.Mail;
using System.Web.Mvc;

namespace uStoreMvc.Controllers
{
    public class HomeController : Controller
    {
        //for use in testing custom error page 
        public ActionResult Sorry()
        {
            throw new System.Exception("Oops! Something went wrong.  We will fix it soon!");
        }


        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult FAQ()
        {
            ViewBag.Message = "Frequently Asked Questions";

            return View();
        }

        [HttpGet]
        //[Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "About Our Company";

            return View();
        }



        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Us!";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(Models.ContactViewModel contactInfo)
        {
            if (!ModelState.IsValid)
            {
                return View(contactInfo);
            }//if - modelstate not valid

            // make the email 
            string body = string.Format(
                $"firstname: {contactInfo.firstname}<br />"
                + $"lastname: {contactInfo.lastname}<br />"
                + $"email: {contactInfo.email}<br />"
                + $"subject: {contactInfo.subject}<br />"
                + $"message: {contactInfo.message}");

            // create the mailmessage object - System.Net.Mail

            MailMessage msg = new MailMessage(
                "no-reply@jenmcook.com",
                "jenmcook@outlook.com",
                contactInfo.subject, body);

            //set MailMessage objects properties
            msg.IsBodyHtml = true;
            msg.CC.Add("JenMCook@outlook.com");

            // SMTP client needs created and config'd
            SmtpClient client = new SmtpClient("mail.jenmcook.com");
            client.Credentials = new NetworkCredential("no-reply@jenmcook.com", "FakePassword");
            client.EnableSsl = false;
            client.Port = 25;

            //use SMTP client object to sent email
            using (client)
            {
                try
                {
                    client.Send(msg);
                } // try
                catch
                {
                    //message if failed to send
                    ViewBag.ErrorMessage = "An error has occurred in sending your message.\n"
                        + "Please try again";
                    return View();
                } //catch
            } // using - cient

            //if message is sent successfully
            return View("ContactConfirmation", contactInfo);

        } //  email
    } // end class
}// end namespace
