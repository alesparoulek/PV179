using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobsPortal.Infrastructure;

namespace PV179.entities
{
    public class Company : IEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public List<JobOffer> Offers {get;set;}

    }
}
