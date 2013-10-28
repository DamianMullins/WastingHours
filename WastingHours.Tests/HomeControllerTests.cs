using NUnit.Framework;
using System.Web.Mvc;
using WastingHours.Controllers;

namespace WastingHours.Tests
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void Index_HttpGet_ExpectedResult()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            ActionResult result = controller.Index();

            // Assert
            Assert.IsInstanceOf<ActionResult>(result);
        }
    }
}
