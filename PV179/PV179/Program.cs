using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV179
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new MyDbContext())
            {
                Console.WriteLine(db.Companies.First().Name);
                Console.WriteLine(db.Companies.First().Id);
                Console.WriteLine(db.Companies.Where(a => a.Login == "bcomp").ToList().First().Id);
                Console.ReadLine();
            }
        }
    }
}
