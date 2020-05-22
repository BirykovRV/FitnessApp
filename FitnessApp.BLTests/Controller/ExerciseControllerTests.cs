using Microsoft.VisualStudio.TestTools.UnitTesting;
using FitnessApp.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using FitnessApp.BL.Model;

namespace FitnessApp.BL.Controller.Tests
{
    [TestClass()]
    public class ExerciseControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            // Arrange
            var userName = Guid.NewGuid().ToString();
            var activityName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userController = new UserController(userName);
            var exerciseController = new ExerciseController(userController.CurrentUser);
            var activity = new Activity(activityName, rnd.Next(10, 59));
            // Act
            exerciseController.Add(activity, DateTime.Now, DateTime.Now.AddHours(1));
            // Assert
            Assert.AreEqual(activityName, exerciseController.Exercises.FirstOrDefault(a => a.Activity.Name == activity.Name).Activity.Name);
            Assert.AreEqual(activityName, exerciseController.Activities.FirstOrDefault(a => a.Name == activity.Name).Name);
        }
    }
}