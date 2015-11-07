using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class Analytic
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public IDictionary<string, decimal> SumByOnus { get; set; }
    }
}