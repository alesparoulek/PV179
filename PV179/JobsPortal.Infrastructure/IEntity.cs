using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsPortal.Infrastructure
{
    public interface IEntity
    {
        /// <summary>
        /// Unique id of the entity.
        /// </summary>
        int Id { get; set; }
    }
}
