using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserApplication.Models;

namespace UserApplication.ViewModels
{
    public class DropDownViewModel
    {
        public IEnumerable<AreaOfComplaint> areas { get; set; }
        public IEnumerable<FieldOfComplaint> fields { get; set; }
        public IEnumerable<ChannelOfComplaint> channels { get; set; }
    }


}
