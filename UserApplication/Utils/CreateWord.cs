using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Microsoft.Office.Interop.Word;
using UserApplication.Models;

namespace UserApplication.Utils
{
    public class CreateWord
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public string Createwodfile(int Id)
        {
            var ComplaintInfo = db.complaints.Find(Id);
            var dateconvert = Convert.ToDateTime(ComplaintInfo.ComplaintDate).ToString("MM/dd/yyyy hh:mm tt");
            string imageURL = HttpContext.Current.Server.MapPath("~/Template/check.JPG");
            string path = "~/savedoc/" + Guid.NewGuid() + "/";
             string DocSavePath = HttpContext.Current.Server.MapPath(path);
          
            string Templatepath = HttpContext.Current.Server.MapPath("~/Template/Complaintsword.docx");
            string newfolderpath = DocSavePath + "\\";

            if (!Directory.Exists(newfolderpath))
                Directory.CreateDirectory(newfolderpath);

            string newFile = newfolderpath + ComplaintInfo.Name + "-Complaint.docx";

            Application app = new Application();
             Document doc = new Document();
            doc = app.Documents.Open(Templatepath);
            doc.Activate();
            if (doc.Bookmarks.Exists("date"))
            {

                doc.Bookmarks["date"].Range.Text = dateconvert;

              }
            if (doc.Bookmarks.Exists("phonenumber"))
            {
                doc.Bookmarks["phonenumber"].Range.Text = ComplaintInfo.PhoneNumber.ToString();

            }
       
            if (ComplaintInfo.Email != null) { 
            if (doc.Bookmarks.Exists("email"))
            {
                doc.Bookmarks["email"].Range.Text = ComplaintInfo.Email.ToString();

            }

            }

            if (doc.Bookmarks.Exists("name"))
            {
                doc.Bookmarks["name"].Range.Text = ComplaintInfo.Name.ToString();

            }

           if (ComplaintInfo.EmirateID != null)
            {
                if (doc.Bookmarks.Exists("emirate"))
                {
                     doc.Bookmarks["emirate"].Range.Text = ComplaintInfo.EmirateID.ToString();
                  
                }

           }
            if (ComplaintInfo.Area != null)
            {
                if (doc.Bookmarks.Exists("area"))
                {
                          doc.Bookmarks["area"].Range.Text = ComplaintInfo.Area.ToString();
                       
                    }

            }
            if (ComplaintInfo.SchoolTransportService) { 
            if (doc.Bookmarks.Exists("schoolTransportService"))
            {

                var shape = doc.Bookmarks["schoolTransportService"].Range.InlineShapes.AddPicture(imageURL, false, true);
                shape.Width = 10;
                shape.Height = 10;
                app.Visible = true;
            }
            }
            if (ComplaintInfo.LogisticsService)
           {
                if (doc.Bookmarks.Exists("logisticsService"))
                {

                    var shape = doc.Bookmarks["logisticsService"].Range.InlineShapes.AddPicture(imageURL, false, true);
                    shape.Width = 10;
                    shape.Height = 10;
                    app.Visible = true;
                }
            }
            if (ComplaintInfo.TransportationRentalService)
            {
                if (doc.Bookmarks.Exists("transportationRentalService"))
                {

                    var shape = doc.Bookmarks["transportationRentalService"].Range.InlineShapes.AddPicture(imageURL, false, true);
                    shape.Width = 10;
                    shape.Height = 10;
                    app.Visible = true;
                }
            }
            if (ComplaintInfo.AdministrativeNote)
            {
                if (doc.Bookmarks.Exists("administrativeNote"))
                {

                    var shape = doc.Bookmarks["administrativeNote"].Range.InlineShapes.AddPicture(imageURL, false, true);
                    shape.Width = 10;
                    shape.Height = 10;
                    app.Visible = true;
                }
            }
            if (ComplaintInfo.ExecutiveNote)
            {
                if (doc.Bookmarks.Exists("executiveNote"))
                {

                    var shape = doc.Bookmarks["executiveNote"].Range.InlineShapes.AddPicture(imageURL, false, true);
                    shape.Width = 10;
                    shape.Height = 10;
                    app.Visible = true;
                }
            }
            if (ComplaintInfo.TechnicalNote)
           {
                if (doc.Bookmarks.Exists("technicalNote"))
                {

                    var shape = doc.Bookmarks["technicalNote"].Range.InlineShapes.AddPicture(imageURL, false, true);
                    shape.Width = 10;
                    shape.Height = 10;
                    app.Visible = true;
                }
            }
           if (ComplaintInfo.Acknowledgment)
            {
                if (doc.Bookmarks.Exists("acknowledgment"))
                {

                    var shape = doc.Bookmarks["acknowledgment"].Range.InlineShapes.AddPicture(imageURL, false, true);
                    shape.Width = 10;
                    shape.Height = 10;
                    app.Visible = true;
                }
            }
            if (ComplaintInfo.Other)
            {
                if (doc.Bookmarks.Exists("other"))
                {

                    var shape = doc.Bookmarks["other"].Range.InlineShapes.AddPicture(imageURL, false, true);
                    shape.Width = 10;
                    shape.Height = 10;
                    app.Visible = true;
                }
            }

           if (ComplaintInfo.OthersDiscription != null)
            {
                if (doc.Bookmarks.Exists("othersDiscription"))
                {

                    doc.Bookmarks["othersDiscription"].Range.Text = ComplaintInfo.OthersDiscription.ToString();
                }
            }

            if (doc.Bookmarks.Exists("fieldOfComplaintName"))
            {
             var  Field = ComplaintInfo.fieldOfComplaint.FieldOfComplaintName;
                doc.Bookmarks["fieldOfComplaintName"].Range.Text = Field;

            }
            if (doc.Bookmarks.Exists("channelOfComplaintName"))
            {
                var channel = ComplaintInfo.channelOfComplaint.ChannelOfComplaintName.ToString();
                doc.Bookmarks["channelOfComplaintName"].Range.Text = channel;

            }

            if (doc.Bookmarks.Exists("areaOfComplaintName"))
            {
                var Area = ComplaintInfo.areaOfComplaint.AreaOfComplaintName.ToString();
                doc.Bookmarks["areaOfComplaintName"].Range.Text = Area;

            }

            if (ComplaintInfo.IsExisiting)
            {
                if (doc.Bookmarks.Exists("isExisiting"))
                {

                    var shape = doc.Bookmarks["isExisiting"].Range.InlineShapes.AddPicture(imageURL, false, true);
                    shape.Width = 10;
                    shape.Height = 10;
                    app.Visible = true;
                }
            }
            else
            {
                if (doc.Bookmarks.Exists("FirstEntry"))
                {

                    var shape = doc.Bookmarks["FirstEntry"].Range.InlineShapes.AddPicture(imageURL, false, true);
                    shape.Width = 10;
                    shape.Height = 10;
                    app.Visible = true;
                }

            }
            if (ComplaintInfo.Complicated)
            {
                if (doc.Bookmarks.Exists("complicated"))
                {

                    var shape = doc.Bookmarks["complicated"].Range.InlineShapes.AddPicture(imageURL, false, true);
                    shape.Width = 10;
                    shape.Height = 10;
                    app.Visible = true;
                }
            }
            if (ComplaintInfo.Urgent)
            {
                if (doc.Bookmarks.Exists("urgent"))
                {

                    var shape = doc.Bookmarks["urgent"].Range.InlineShapes.AddPicture(imageURL, false, true);
                    shape.Width = 10;
                    shape.Height = 10;
                    app.Visible = true;
                }
            }
            if (ComplaintInfo.Normal)
            {
                if (doc.Bookmarks.Exists("normal"))
                {

                    var shape = doc.Bookmarks["normal"].Range.InlineShapes.AddPicture(imageURL, false, true);
                    shape.Width = 10;
                    shape.Height = 10;
                    app.Visible = true;
                }
            }
           if (ComplaintInfo.ChannelOfReceivingID != null)
            {
                if (doc.Bookmarks.Exists("callCenter"))
                {

                    var shape = doc.Bookmarks["callCenter"].Range.InlineShapes.AddPicture(imageURL, false, true);
                    shape.Width = 10;
                    shape.Height = 10;
                    app.Visible = true;
              }
            }

            if (doc.Bookmarks.Exists("addedBy"))
            {
                doc.Bookmarks["addedBy"].Range.Text = ComplaintInfo.AddedBy.ToString();

            }

            if (doc.Bookmarks.Exists("addedTime"))
            {
                doc.Bookmarks["addedTime"].Range.Text = ComplaintInfo.AddedTime.ToString();

            }

          
          

            doc.SaveAs2(newFile);
            app.Application.Quit();
            return newFile;

        }



    }
}