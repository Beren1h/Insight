using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Models
{
    public class Entry
    {
        public string _id { get; set; }
        public DateTime Date { get; set; }
        public Decimal Amount { get; set; }
        public IEnumerable<LineItem> LineItems { get; set; }
    }
}