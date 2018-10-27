using System;
using System.Threading.Tasks;
using JobsPortal.Infrastructure;
using JobsPortal.Infrastructure.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PV179.entities;

namespace Tests
{
    [TestClass]
    public class UserRepositoryTests
    {
        private readonly IRepository<User> userRepository = new EntityFrameworkRepository<User>(Initializer.Provider);

        private readonly Guid FrantaId = Guid.Parse("aa05dc64-5c07-40fe-a916-175165b9b90f");

        [TestMethod]
        public async Task TestMethod1()
        {
            // Arrange
            User user1 = new User()
            {
                FirstName = "Franta",
                LastName = "Kuldanu",
                Email = "frantakuldanu@seznam.cz",
                Phone = "0609112567",
                Education = PV179.enums.Education.graduated_highschool
            };

            User user2 = new User();

            // Act
            using (Initializer.Provider.Create())
            {
                user2 = await userRepository.GetAsync(user1.Id);
            }

            // Assert
            Assert.AreEqual(user1.FirstName, user2.FirstName);
        }
    }
}
