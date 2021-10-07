using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserApplication.Models
{
    public class EmailDepartments
    {
        [Key]
        public int DId { get; set; }
        public string Department_Names { get; set; }

        public string Email_Address { get; set; }



    }
}