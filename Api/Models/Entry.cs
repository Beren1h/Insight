using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class Entry
    {
        public ObjectId _id { get; set; }
        public DateTime Date { get; set; }
        public Decimal Amount { get; set; }
        public IEnumerable<LineItem> LineItems { get; set; }
    }
}