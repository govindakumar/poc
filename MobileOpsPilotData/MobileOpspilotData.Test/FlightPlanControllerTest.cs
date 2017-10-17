using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web;
using MobileOpsPilotData.Service;
using System.Collections.Generic;
using MobileOpsPilotData.Service.Models;
using MobileOpsPilotData.Controllers.V3;
using System.Web.Http;
using System.Web.Http.Results;

namespace MobileOpspilotData.Test
{
    [TestClass]
    public class FlightPlanControllerTest
    {
        private Mock<IFlightPlanService> mockService;
        [TestInitialize]
        public void TestInitialize()
        {
            mockService = new Mock<IFlightPlanService>();
        }

        [TestMethod]
        public void GetFlightPlansTest()
        {
            //Arrange
            var lstFlightPlan = new List<FlightPlan>();
            lstFlightPlan.Add(new FlightPlan { FlightNumber = "EAD009" });
            mockService.Setup(x => x.GetFlightPlans())
                .Returns(lstFlightPlan);

            var controller = new FlightPlansV3Controller(mockService.Object);

            // Act
            IHttpActionResult actionResult = controller.GetFlightPlans();
            var contentResult = actionResult as OkNegotiatedContentResult<IEnumerable<FlightPlan>>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            string fN=string.Empty;
            foreach(var item in contentResult.Content)
            {
                fN = item.FlightNumber;
                break;
            }
            Assert.AreEqual(lstFlightPlan[0].FlightNumber,fN);
        }

        public void GetCurrentFlightPlanTest()
        {

        }
    }
}
