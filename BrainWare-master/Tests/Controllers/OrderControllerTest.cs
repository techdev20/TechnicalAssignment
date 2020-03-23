using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Web;
using Web.Controllers;

namespace Tests.Controllers
{
    [TestClass]
    public class OrderControllerTest
    {
        [TestMethod]
        public void GetOrders()
        {
            // Arrange
            OrderController controller = new OrderController();

            // Act
            var result = controller.GetOrders(1);

            // Assert
            Assert.IsNotNull(result ,"Empty order");
        }
    }
}
