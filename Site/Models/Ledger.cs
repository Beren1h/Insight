using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Models
{
    public class Ledger
    {
        public DateTime Pay { get; set; }
        public DateTime Next { get; set; }
        public DateTime AsDate { get; set; }
    }
}