using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Models
{
    public class LineItem
    {
        public DateTime Date { get; set; }
        public Decimal Amount { get; set; }
        public int Tag { get; set; }
        public string Memo { get; set; }
    }
}