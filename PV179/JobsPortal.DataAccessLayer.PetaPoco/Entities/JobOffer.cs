using JobsPortal.Infrastructure;
using System;
using System.Collections.Generic;
using AsyncPoco;
using JobsPortal.DataAccessLayer.PetaPoco;
using PV179.enums;

namespace PV179.entities
{
    [TableName(TableNames.JobOfferTable)]
    [PrimaryKey("Id", autoIncrement = false)]
    public class JobOffer : IEntity
    {
        public Guid Id { get; set; }

        [Ignore]
        public string TableName { get; } = TableNames.JobOfferTable;

        public Guid CompanyId { get; set; }

        [Ignore] 
        public virtual Company Company { get; set; }

        public JobType JobType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeJob TimeJob { get; set; }
        public Location Location { get; set; }
        public Education Education { get; set; }
        public int Salary { get; set; }
        public List<string> Questionnaire { get; set; }
        public virtual List<Application> Applications { get; set; }
        public DateTime Date { get; set; }
    }
}
