using JobsPortal.Infrastructure;
using System;
using AsyncPoco;
using JobsPortal.DataAccessLayer.PetaPoco.Enums;

namespace JobsPortal.DataAccessLayer.PetaPoco.Entities
{
    [TableName(TableNames.UserTable)]
    [PrimaryKey("Id", autoIncrement = false)]
    public class User : IEntity
    {
        public Guid Id { get; set; }

        [Ignore]
        public virtual string TableName { get; } = TableNames.UserTable;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Education Education { get; set; }
        
    }
}
