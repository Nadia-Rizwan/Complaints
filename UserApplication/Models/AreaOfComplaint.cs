using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserApplication.Models
{
    public class AreaOfComplaint
    {
        [Key]
        public int AreaOfComplaintID { get; set; }

        public string AreaOfComplaintName { get; set; }


    }
}