using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies21Xsis.Models
{
    public class WebResponse
    {
        public bool status { get; set; }
        public string message { get; set; }
        public object data { get; set; }
    }
}
