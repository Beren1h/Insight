using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api;

namespace Exe
{
    class Program
    {
        static void Main(string[] args)
        {
            var contenxt = new MongoContext();
            var read = contenxt.TestRead();

            Console.WriteLine(read);

            //Console.Read();
        }
    }
}
