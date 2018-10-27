using JobsPortal.Infrastructure;
using System;
using System.Collections.Generic;
using AsyncPoco;

namespace JobsPortal.DataAccessLayer.PetaPoco.Entities
{
    [TableName(TableNames.CompanyTable)]
    [PrimaryKey("Id", autoIncrement = false)]
    public class Company : IEntity
    {
        public Guid Id { get; set; }

        [Ignore]
        public string TableName { get; } = TableNames.CompanyTable;

        public string Name { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public virtual List<JobOffer> Offers { get; set; }

    }
}
