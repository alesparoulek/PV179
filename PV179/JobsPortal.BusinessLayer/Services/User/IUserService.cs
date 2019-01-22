using JobsPortal.BusinessLayer.DataTransferObjects;
using JobsPortal.BusinessLayer.DataTransferObjects.Common;
using JobsPortal.BusinessLayer.DataTransferObjects.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsPortal.BusinessLayer.Services
{
    public interface IUserService
    {

        /// <summary>
        /// Gets customer with given email address
        /// </summary>
        /// <param name="email">email</param>
        /// <returns>Customer with given email address</returns>
        Task<UserDto> GetCustomerAccordingToEmailAsync(string email);

        /// <summary>
        /// Gets DTO representing the entity according to ID
        /// </summary>
        /// <param name="entityId">entity ID</param>
        /// <param name="withIncludes">include all entity complex types</param>
        /// <returns>The DTO representing the entity</returns>
        Task<UserDto> GetAsync(Guid entityId, bool withIncludes = true);

        /// <summary>
        /// Creates new entity
        /// </summary>
        /// <param name="entityDto">entity details</param>
        Guid Create(UserDto entityDto);
        

        /// <summary>
        /// Updates entity
        /// </summary>
        /// <param name="entityDto">entity details</param>
        Task Update(UserDto entityDto);

        /// <summary>
        /// Deletes entity with given Id
        /// </summary>
        /// <param name="entityId">Id of the entity to delete</param>
        void Delete(Guid entityId);
        
    }
}
