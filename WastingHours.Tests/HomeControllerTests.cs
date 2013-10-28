using Moq;
using NUnit.Framework;
using System.Web.Mvc;
using WastingHours.Controllers;
using WastingHours.Infrastructure.Abstract;

namespace WastingHours.Tests
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void Index_HttpGet_ExpectedResult()
        {
            // Arrange
            var blogPostService = new Mock<IBlogPostService>();
            var controller = new HomeController(blogPostService.Object);

            // Act
            ActionResult result = controller.Index();

            // Assert
            Assert.IsInstanceOf<ActionResult>(result);
        }
    }
}
