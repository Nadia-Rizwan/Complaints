using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UserApplication.Models
{
    public class Complaint
    {
        [Key]
        public int ID { get; set; }

        
        [Display(Name = "ComplaintDate", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "DateRequired")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ComplaintDate { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "PhoneNumberRequired")]
        [Display(Name = "PhoneNumber", ResourceType = typeof(Resource))]
        public string  PhoneNumber { get; set; }


        [Display(Name = "Email", ResourceType = typeof(Resource))]
        [DataType(DataType.EmailAddress, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "InvalidEmail")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "NameRequired")]
        [Display(Name = "Name", ResourceType = typeof(Resource))]
        public string  Name { get; set; }

        [Display(Name = "EmirateID", ResourceType = typeof(Resource))]
        public string  EmirateID { get; set; }

        [Display(Name = "Area", ResourceType = typeof(Resource))]
        public string Area  { get; set; }


        [Display(Name = "SchoolTransportService", ResourceType = typeof(Resource))]
        public bool SchoolTransportService { get; set; }

        [Display(Name = "LogisticsService", ResourceType = typeof(Resource))]
        public bool LogisticsService { get; set; }

        [Display(Name = "TransportationRentalService", ResourceType = typeof(Resource))]
        public bool TransportationRentalService { get; set; }


        [Display(Name = "AdministrativeNote", ResourceType = typeof(Resource))]
        public bool AdministrativeNote { get; set; }
        [Display(Name = "ExecutiveNote", ResourceType = typeof(Resource))]
        public bool ExecutiveNote { get; set; }
        [Display(Name = "TechnicalNote", ResourceType = typeof(Resource))]
        public bool TechnicalNote { get; set; }
        [Display(Name = "Acknowledgment", ResourceType = typeof(Resource))]
        public bool Acknowledgment { get; set; }
        [Display(Name = "Other", ResourceType = typeof(Resource))]
        public bool Other{ get; set; }
        [Display(Name = "OthersDiscription", ResourceType = typeof(Resource))]
        public string  OthersDiscription { get; set; }






        [Display(Name = "IsExisiting", ResourceType = typeof(Resource))]
        public bool IsExisiting { get; set; }


        [Display(Name = "Normal", ResourceType = typeof(Resource))]
        public bool Normal { get; set; }
        [Display(Name = "Urgent", ResourceType = typeof(Resource))]
        public bool Urgent { get; set; }
        [Display(Name = "Complicated", ResourceType = typeof(Resource))]
        public bool Complicated { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "ChannelOfReceivingIDRequired")]
        [Display(Name = "ChannelOfReceivingID", ResourceType = typeof(Resource))]
        public string ChannelOfReceivingID { get; set; }

       

      [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "AreaRequired")]
        public int AreaOfComplaintID { get; set; }

        [ForeignKey("AreaOfComplaintID")]
        public virtual AreaOfComplaint areaOfComplaint { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "ChannelRequired")]
        public int ChannelOfComplaintID { get; set; }

        [ForeignKey("ChannelOfComplaintID")]
        public virtual ChannelOfComplaint channelOfComplaint { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "FieldRequired")]
        public int FieldOfComplaintID { get; set; }

        [ForeignKey("FieldOfComplaintID")]
        public virtual FieldOfComplaint fieldOfComplaint { get; set; }


        public string NoteNumber { get; set; }

    
        public string AddedBy { get; set; }

        public DateTime AddedTime { get; set; }


       

        
     

    }



}