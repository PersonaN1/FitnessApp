using System;
using FitnessMainLogic.Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FitnessTests
{
    [TestClass]
    public class UserControllerTests
    {

        [TestMethod()]
        public void SetNewUserDataTest()
        {
            //arrange
            var userName = Guid.NewGuid().ToString();
            var birthday = DateTime.Now.AddYears(-18);
            var gender = "man";
            var weight = 90;
            var height = 180;
            var controller = new UserController(userName);
            //act
            controller.SetNewUserData(gender, birthday, weight, height);
            var controller2 = new UserController(userName);
            //assert
            Assert.AreEqual(userName, controller2.CurrentUser.Name);
        }
        [TestMethod()]
        public void SaveTest()
        {
            //Arrange


            var userName = Guid.NewGuid().ToString();

            //Act

            var controller = new UserController(userName);
            //Assert
            Assert.AreEqual(userName, controller.CurrentUser.Name);
        }
    }
}
