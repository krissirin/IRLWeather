using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IRLWeather.Models;
using IRLWeather.Controllers;

namespace IRLWeather.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }

        [TestClass]
        public class UnitTestModel
        {
            // Test adding a new weather and verifies that two specified objects are equal 
            // within the specified accuracy of each other. 
            // The assertion fails if the objects are not equal.
            [TestMethod]
            public void TestWeather()
            {

                Weather w = new Weather()
                {
                    Id = 1,
                    City = "Belfast",
                    todaysCondition = "Cloudy",
                    MaxTemp = 10,
                    MinTemp = 1,
                    WindDirection = "East",
                    WindSpeed = 5,
                    tomorrowsCondition = "Rain",
                };
                Assert.AreEqual(1, w.Id);
                Assert.AreEqual("Belfast", w.City);
                Assert.AreEqual("Cloudy", w.todaysCondition);
                Assert.AreEqual(10, w.MaxTemp);
                Assert.AreEqual(1, w.MinTemp);
                Assert.AreEqual("East", w.WindDirection);
                Assert.AreEqual(5, w.WindSpeed);
                Assert.AreEqual("Rain", w.tomorrowsCondition);

            }
        }
    }
}
