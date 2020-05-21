using Microsoft.VisualStudio.TestTools.UnitTesting;
using FitnessApp.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessApp.BL.Model;

namespace FitnessApp.BL.Controller.Tests
{
    [TestClass()]
    public class EatingControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            // Arrange
            var name = Guid.NewGuid().ToString();
            var foodName = Guid.NewGuid().ToString();
            var num = new Random();
            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var food = new Food(foodName, num.Next(0, 999), num.Next(0, 999), num.Next(0, 999), num.Next(0, 999));
            // Act
            eatingController.Add(food, 100.0);
            // Assert
            Assert.AreEqual(food.Name, eatingController.Eating.Foods.FirstOrDefault(f => f.Key == food).Key.Name);
        }
    }
}