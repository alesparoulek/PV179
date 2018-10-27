using System.Collections.Generic;
using AsyncPoco;

namespace JobsPortal.DataAccessLayer.PetaPoco.Entities
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
