using JobsPortal.Infrastructure;
using System;
using System.Collections.Generic;
using AsyncPoco;
using Utilities.Enums;

namespace JobsPortal.DataAccessLayer.PetaPoco.Entities
{
    [TableName(TableNames.ApplicationTable)]
    [PrimaryKey("Id", autoIncrement = false)]
    public class Application : IEntity
    {
        public Guid Id { get; set; }

        [Ignore]
        public string TableName { get; } = TableNames.ApplicationTable;

        public Guid JobOfferId { get; set; }
        public Guid UserId { get; set; }

        [Ignore]
        public virtual JobOffer JobOffer { get; set; }

        [Ignore]
        public User User { get; set; }

        public List<string> Answers { get; set; }
        public JobOfferState JobOfferState { get; set; }
        public UserState UserState { get; set; }
    }
}
