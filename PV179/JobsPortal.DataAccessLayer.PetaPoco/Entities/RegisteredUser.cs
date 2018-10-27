using JobsPortal.Infrastructure;
using System;
using System.Collections.Generic;
using AsyncPoco;
using JobsPortal.DataAccessLayer.PetaPoco;
using PV179.enums;

namespace PV179.entities
{
    [TableName(TableNames.RegisteredUserTable)]
    [PrimaryKey("Id", autoIncrement = false)]
    public class RegisteredUser : User
    {
        [Ignore]
        public override string TableName { get; } = TableNames.RegisteredUserTable;

        public string Login { get; set; }
        public string Password { get; set; }
        public List<Application> Applications { get; set; }
    }
}
