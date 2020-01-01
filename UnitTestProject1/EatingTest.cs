using System;
using FitnessMainLogic.Controller;
using FitnessMainLogic.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
namespace FitnessTests
{
    [TestClass]
    public class EatingTest
    {

        [TestMethod()]
        public void AddTest()
        {
            var rdn = new Random();
            //Arrange
            var userName = Guid.NewGuid().ToString();
            var foodName = Guid.NewGuid().ToString();
            var userController = new UserController(userName);
            var eatingController = new EatingController(userController.CurrentUser);

            var food = new Food(foodName, rdn.Next(50, 500), rdn.Next(50, 500), rdn.Next(50, 500), rdn.Next(50, 500));

            //Act
            eatingController.Add(food, 100);

            //Assert

            Assert.AreEqual(food.Name, eatingController.Eating.Foods.First().Key.Name);
        }
        
    }
}
