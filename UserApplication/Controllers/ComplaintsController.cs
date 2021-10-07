using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UserApplication.Models;
using UserApplication.Utils;
using UserApplication.ViewModels;

namespace UserApplication.Controllers
{
    public class ComplaintsController : MyController
    {

  


        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Complaints
     
        public ActionResult Index()
        {  try { 
            if (User.IsInRole("Admin")) { 
                return View(db.complaints.ToList());
            }

            var SessionUserId = User.Identity.GetUserName();
            var ComplaintList = db.complaints.Where(x => x.AddedBy == SessionUserId).ToList();

            return View(ComplaintList);
        }

            catch (Exception ex)
            {

                throw;
            }


        }

        // GET: Complaints/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
          
            Complaint complaint = db.complaints.Find(id);
            if (complaint == null)
            {
                return HttpNotFound();
            }

            var field = complaint.fieldOfComplaint.FieldOfComplaintName;
            ViewBag.selectedField = field;
            var area = complaint.areaOfComplaint.AreaOfComplaintName;
            ViewBag.SelectedArea = area;
            var channel = complaint.channelOfComplaint.ChannelOfComplaintName;
            ViewBag.SelectedChannel = channel;
            return View(complaint);
        }

        // GET: Complaints/Create
        public ActionResult Create()
        {
            var fields = db.fieldOfComplaints.ToList();
           
            ViewBag.Field = new SelectList(fields, "FieldOfComplaintID", "FieldOfComplaintName");

            var areas = db.areaOfComplaints.ToList();
            ViewBag.Area = new SelectList(areas, "AreaOfComplaintID", "AreaOfComplaintName");
       

            var channels = db.channelOfComplaints.ToList();
            ViewBag.Channel = new SelectList(channels, "ChannelOfComplaintID", "ChannelOfComplaintName");
           

            return View();
        }

        // POST: Complaints/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Complaint complaint)
        {
            try { 
            if (ModelState.IsValid)
            {

                    var SessionUserName = User.Identity.Name;
                    string CurrentUserName = Convert.ToString(SessionUserName);
                    complaint.AddedBy = CurrentUserName;
                    var time = DateTime.Now;
                   complaint.AddedTime = time;
                
                db.complaints.Add(complaint);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(complaint);
            }

            catch (Exception)
            {
                throw;
            }


        }
    

        // GET: Complaints/Edit/5
        public ActionResult Edit(int? id)
        {
             
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

          
            Complaint complaint = db.complaints.Find(id);

            if (complaint == null)
            {
                return HttpNotFound();
            }
            var fields = db.fieldOfComplaints.ToList();
            ViewBag.FieldOfComplaintID = new SelectList(fields, "FieldOfComplaintID", "FieldOfComplaintName", complaint.FieldOfComplaintID);

            var areas = db.areaOfComplaints.ToList();
            ViewBag.AreaOfComplaintID = new SelectList(areas, "AreaOfComplaintID", "AreaOfComplaintName", complaint.AreaOfComplaintID);

            var Channel= db.channelOfComplaints.ToList();
            ViewBag.ChannelOfComplaintID = new SelectList(Channel, "ChannelOfComplaintID", "ChannelOfComplaintName", complaint.ChannelOfComplaintID);
           
            return View(complaint);
        }

        // POST: Complaints/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Complaint complaint)
        {
            try {
                if (ModelState.IsValid)
                {
                    var SessionUserName = User.Identity.Name;
                    string CurrentUserName = Convert.ToString(SessionUserName);
                    complaint.AddedBy = CurrentUserName;
                    complaint.AddedTime = DateTime.Now;


                    db.Entry(complaint).State = EntityState.Modified;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(complaint);
            }

            catch (Exception ex)
            {
                throw;
            }


        }
        /*
               // GET: Complaints/Delete/5
               public ActionResult Delete(int? id)
               {
                   if (id == null)
                   {
                       return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                   }
                   Complaint complaint = db.complaints.Find(id);
                   if (complaint == null)
                   {
                       return HttpNotFound();
                   }
                   return View(complaint);
               }

               // POST: Complaints/Delete/5
               [HttpPost, ActionName("Delete")]
               [ValidateAntiForgeryToken]
               public ActionResult DeleteConfirmed(int id)
               {
                   Complaint complaint = db.complaints.Find(id);
                   db.complaints.Remove(complaint);
                   db.SaveChanges();
                   return RedirectToAction("Index");
               }

           */

        [HttpPost]
  
        public ActionResult Delete(int id)
        {
            try
            {
                Complaint complaint = db.complaints.Find(id);
                if (complaint == null)
                {
                    return HttpNotFound();
                }
                db.complaints.Remove(complaint);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        //public ActionResult createpdf(int id)
        //{
        //    string file = new CreatePDF().generateFATCA(id);

        //    var user = db.complaints.Find(id);


        //   // string path = "~/Uploads/" + Guid.NewGuid() + "/";
        //    try
        //    {

        //        MailMessage mailMessage = new MailMessage();
        //        mailMessage.From = new MailAddress("asif.iqbal@backofficeme.com");
        //        mailMessage.To.Add(new MailAddress("nadiaarshaad@gmail.com"));
        //        mailMessage.Subject = "Complaint Form";
        //        //  Directory.CreateDirectory(Server.MapPath(path));
        //        // string filePath = Server.MapPath(path + file);


        //        Attachment data=new Attachment(file);
        //        mailMessage.Attachments.Add(data);

        //        mailMessage.IsBodyHtml = false;

        //        SmtpClient smtp = new SmtpClient();
        //        smtp.Host = "bosmtp.zee-supreme-vps.net";
        //        smtp.Port = 26;
        //        smtp.EnableSsl = true;
        //        NetworkCredential networkCredential = new NetworkCredential("mail@bosmtp2.zee-supreme-vps.net", "dlw1uK4Z");
        //        smtp.UseDefaultCredentials = true;
        //        smtp.Credentials = networkCredential;
        //        smtp.Send(mailMessage);
        //        ViewBag.Message = "Sent";


        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //    return View();

        //}

            /*
        public ActionResult ActionForm(int id)
        {

            try
            {
                string file = new CreatePDF().generateFATCA(id);
                bool emailsent = SendEmail(id,file);
               
                if (emailsent)
                {

                    var directoryName = Path.GetDirectoryName(file);
                    // If directory does not exist, don't even try   
                    if (Directory.Exists(directoryName))
                    {
                    // Directory.Delete(directoryName,true);

                }

                }
                return RedirectToAction("Index");

            }

            catch (Exception ex)
            {

            }
            return RedirectToAction("Error","Home");

        }


       */

        public bool SendEmail(string emailaddress,string file)
        {
           
           
            try
            {
                

                System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
                mailMessage.From = new MailAddress("asif.iqbal@backofficeme.com");
               // mailMessage.To.Add(new MailAddress("nadiaarshaad@gmail.com"));
                mailMessage.Subject = "Complaint Form";
               
                if (emailaddress != null)
                {


                    if (emailaddress != "")
                    {
                        if (emailaddress.Contains(';'))
                        {

                            string[] To = emailaddress.Split(';');
                            foreach (string ToEmail in To)
                            {
                                if (ToEmail != "")
                                    mailMessage.To.Add(new MailAddress(ToEmail));
                            }


                        }
                        else
                        {
                            string ToEmail = emailaddress;
                            mailMessage.To.Add(new MailAddress(ToEmail));
                        }
                    }

                }

                Attachment data = new Attachment(file);
                mailMessage.Attachments.Add(data);

                mailMessage.IsBodyHtml = false;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "bosmtp.zee-supreme-vps.net";               
                smtp.Port = 26;
                smtp.EnableSsl = true;
                NetworkCredential networkCredential = new NetworkCredential("mail@bosmtp.zee-supreme-vps.net", "liuXvW@l[S!8");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = networkCredential;

                smtp.Send(mailMessage);
                TempData["Message"] = "sent";
                return true;


            }
            catch (Exception ex)
            {
               
            }
            TempData["fail"] = "fail";
            return false;

        }

/*
        public ActionResult Actionword(int id)
        {
            try {
                string file = new CreateWord().Createwodfile(id);
                bool emailsent = SendEmail(id, file);

                if (emailsent)
                {

                    var directoryName = Path.GetDirectoryName(file);
                    // If directory does not exist, don't even try   
                    if (Directory.Exists(directoryName))
                    {
                        // Directory.Delete(directoryName,true);

                    }

                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {



            }
            return RedirectToAction("Error", "Home");




        }

        */

        public ActionResult EmailDeprtmentIndex()
        {
            try
            {
               

                return View(db.emailDepartments.ToList());
            }

            catch (Exception ex)
            {

                throw;
            }


        }
        public ActionResult CreateEmailDepartment()
        {
            return View();


        }
        [HttpPost]
        public ActionResult CreateEmailDepartment(EmailDepartments emailDepartments)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    
                    db.emailDepartments.Add(emailDepartments);
                    db.SaveChanges();
                    return RedirectToAction("EmailDeprtmentIndex");
                }
                else
                {

                    return View(emailDepartments);
                }


            }

            catch (Exception ex)
            {

                throw;
            }


        }



        public ActionResult SelectEmailDepartment(int id)
        {
            var Deprt = db.emailDepartments.ToList();
            ViewBag.Departments = new SelectList(Deprt, "DId", "Department_Names");

            string FileName = createWordFile(id);
            ViewBag.filename = FileName;

            return View();
        }

        public string createWordFile(int ID)
        {

            string file = new CreateWord().Createwodfile(ID);

            return file;

        }

        [HttpPost]
        public ActionResult SelectEmailDepartment(EmailDepartments emailDepartments,string file)
        {
            
           
            var selectedmail = db.emailDepartments.Find(emailDepartments.DId);
            var receiption = selectedmail.Email_Address.ToString();

            
           // string FileName = createWordFile(id);

            // bool emailsent = SendEmail(receiption, file);
            var Deprt = db.emailDepartments.ToList();
            ViewBag.Departments = new SelectList(Deprt, "DId", "Department_Names");
          
            return View("SelectEmailDepartment");
        }

      

        public ActionResult DeleteDepartments(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailDepartments EmailDeprt = db.emailDepartments.Find(id);
            if (EmailDeprt == null)
            {
                return HttpNotFound();
            }
            return View(EmailDeprt);
        }

        // POST: Complaints/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDepartments(int id)
        {
            EmailDepartments EmailDeprt = db.emailDepartments.Find(id);
            db.emailDepartments.Remove(EmailDeprt);
            db.SaveChanges();
            return RedirectToAction("EmailDeprtmentIndex");
        }
         
        public ActionResult EditEmailDepartment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

           EmailDepartments emailDepartments = db.emailDepartments.Find(id);

            if (emailDepartments == null)
            {
                return HttpNotFound();
            }

            

            return View(emailDepartments);



        }
        [HttpPost]
        public ActionResult EditEmailDepartment(EmailDepartments emailDepartments)
        {


            try
            {
                if (ModelState.IsValid)
                {

                    db.Entry(emailDepartments).State = EntityState.Modified;

                    db.SaveChanges();

                    return RedirectToAction("EmailDeprtmentIndex");
                }
                return View(emailDepartments);
            }

            catch (Exception ex)
            {
                throw;
            }



        }

      
        
        public ActionResult SendEmailMethod(int id)
        {
            try
            {
                EmailDepartments emailDepartments = new EmailDepartments();
                var Comp = db.complaints.Find(id);
                string file = new CreateWord().Createwodfile(id);
                var list =db.emailDepartments.ToList();
                foreach (var o in list) {

                    if (Comp.SchoolTransportService)
                    {
                        if (o.Department_Names.Equals("SchoolTransportService"))
                    {
                      

                            var school = o.Email_Address.ToString();
                            bool emailsent = SendEmail(school, file);

                        }

                       
                    }
                    if (Comp.LogisticsService)
                    {

                        if (o.Department_Names.Equals("LogisticsService"))
                        {

                            var logisticsService = o.Email_Address.ToString();
                            bool emailsent = SendEmail(logisticsService, file);
                        }
                    }

                    if (Comp.TransportationRentalService)
                    {

                        if (o.Department_Names.Equals("TransportationRentalService"))
                        {

                            var transportationRentalService = o.Email_Address.ToString();
                            bool emailsent = SendEmail(transportationRentalService, file);
                        }

                    }


                }

             

              
                //if (Comp.SchoolTransportService)
                //{

                //    var all = db.emailDepartments.Find(10);
                    //var school = emailDepartments.Department_Names.Equals("SchoolTransportService");
                                 
                // //   string file = new CreateWord().Createwodfile(id);
                //    bool emailsent = SendEmail(school, file);

                //}
                //if (Comp.LogisticsService)
                //{

                //    var all = db.emailDepartments.Find(11);
                //    var Logistic = all.Email_Address.ToString();
                //    //string file = new CreateWord().Createwodfile(id);
                //    bool emailsent = SendEmail(Logistic, file);
                //}
                //if (Comp.TransportationRentalService)
                //{

                //    var all = db.emailDepartments.Find(12);
                //    var SchoolRental = all.Email_Address.ToString();
                //   // string file = new CreateWord().Createwodfile(id);
                //    bool emailsent = SendEmail(SchoolRental, file);
                //}

                return RedirectToAction("Index");
            }

            catch (Exception ex)
            {
                throw;
            }


            }


            //public static bool SendAsync(SMTPEmailMessage message)
            //{

            //    try
            //    {
            //        SmtpClient client = null;
            //        ApplicationDbContext db = new ApplicationDbContext();
            //        string fromaddress = "";
            //        var smtpdetails = db.EmailIntegrations.Where(o => o.IsDeleted == false).FirstOrDefault();
            //        if (smtpdetails != null)
            //        {
            //            var host = smtpdetails.SMTPServer;
            //            var port = smtpdetails.PortNo;
            //            var username = smtpdetails.UserName;
            //            var password = smtpdetails.EmailPassword;
            //            fromaddress = smtpdetails.Email;
            //            client = new SmtpClient(host, Convert.ToInt16(port));
            //            client.Credentials = new System.Net.NetworkCredential(username, password);
            //        }

            //        MailMessage mailMessage = new MailMessage();

            //        mailMessage.From = new MailAddress(fromaddress);
            //        if (message.ToRecipients != null && message.ToRecipients.Length > 0)
            //        {
            //            foreach (var email in message.ToRecipients)
            //            {
            //                mailMessage.To.Add(new MailAddress(email));
            //            }
            //        }
            //        if (message.CCRecipients != null && message.CCRecipients.Length > 0)
            //        {
            //            foreach (var email in message.CCRecipients)
            //            {
            //                mailMessage.CC.Add(new MailAddress(email));
            //            }
            //        }
            //        if (message.Attachments != null && message.Attachments.Length > 0)
            //        {
            //            foreach (var attachment in message.Attachments)
            //            {
            //                if (!string.IsNullOrEmpty(attachment))
            //                    mailMessage.Attachments.Add(new Attachment(attachment));
            //            }
            //        }

            //        mailMessage.Subject = message.Subject;
            //        mailMessage.Body = message.Body;

            //        mailMessage.BodyEncoding = Encoding.UTF8;
            //        mailMessage.SubjectEncoding = Encoding.UTF8;
            //        mailMessage.IsBodyHtml = true;

            //        // there can only ever be one-1 concurrent call to SendMailAsync
            //        //await client.SendMailAsync(mailMessage);

            //        client.Send(mailMessage);

            //        return true;
            //    }
            //    catch (Exception ex)
            //    {
            //        var exc = ex;
            //    }
            //    return false;
            //}

            public ActionResult ChangeLanguage(string lang)
        {
            new LanguageManager().SetLanguage(lang);
            return RedirectToAction("Create", "Complaints");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }





    }
}
