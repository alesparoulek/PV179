using PV179.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV179.entities
{
    public class Application
    {
        public int Id { get; set; }
        public int JobOfferId { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
        public List<string> Answers { get; set; }
        public JobOfferState JobOfferState { get; set; }
        public UserState UserState { get; set; }
    }
}
