using JobsPortal.Infrastructure;
using PV179.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV179.entities
{
    public class User : IEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Education Education { get; set; }
        
    }
}
