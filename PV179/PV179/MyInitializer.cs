using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV179
{
    public class MyInitializer : DropCreateDatabaseAlways<MyDbContext>
    {
        protected override void Seed(MyDbContext context)
        {
            context.Companies.Add(new entities.Company
            {
                Login = "a",
                Name = "b",
                Email = "c",
                Password = "d",
                Offers = null               
            });

            context.Companies.Add(new entities.Company
            {
                Login = "g",
                Name = "f",
                Email = "e",
                Password = "h",
                Offers = null
            });

            base.Seed(context);
        }
    }
}
