using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class Simple
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public IEnumerable<Simple> Simples { get; set; }
    }
}