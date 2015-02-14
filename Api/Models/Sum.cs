using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class Sum
    {
        public bool IncludeBalance { get; set; }
        public bool includeOnlyCleared { get; set; }
        public DateTime End { get; set; }
    }
}