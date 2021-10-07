using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserApplication.Models
{
    public class FieldOfComplaint
    {
        [Key]
        public int FieldOfComplaintID { get; set; }

        public string FieldOfComplaintName { get; set; }

    }
}