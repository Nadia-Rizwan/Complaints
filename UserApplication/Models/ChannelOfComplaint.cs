using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserApplication.Models
{
    public class ChannelOfComplaint
    {
        [Key]
        public int ChannelOfComplaintID { get; set; }

        public string ChannelOfComplaintName { get; set; }
    }
}