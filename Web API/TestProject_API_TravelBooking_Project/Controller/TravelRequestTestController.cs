using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_TravelBooking_Project.Controllers;
using API_TravelBooking_Project.Models;
using API_TravelBooking_Project.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace TestProject_API_TravelBooking_Project.Controller
{
    public class TravelRequestTestController
    {
        private readonly Mock<ITravelRequestRepository> _mockRepo;
        private readonly TravelRequestController _controller;
        private IEnumerable<TravelRequest> objList;

        public TravelRequestTestController()
        {
            _mockRepo = new Mock<ITravelRequestRepository>();
            objList = new List<TravelRequest>()
            {
                new TravelRequest{RequestId = 1, EmpId=1, LocFrom = "Pune", LocTo = "Jalgoan", ApprovalStatus="Pending", BookingStatus="Pending", CurrentStatus="Pending"},
                new TravelRequest{RequestId = 2, EmpId=2, LocFrom = "Rahuri", LocTo = "Jalgoan", ApprovalStatus="Pending", BookingStatus="Pending", CurrentStatus="Pending"}
            };

            _mockRepo.Setup(repo => repo.GetTravelRequests()).ReturnsAsync(objList);
            _controller = new TravelRequestController(_mockRepo.Object);
        }
        [Fact]
        public async Task Index_ActionExecutes_ReturnsOkResultForIndex()
        {
            //Act
            var result = await _controller.Get();
            var OkObjectResult = Assert.IsType<ActionResult<IEnumerable<TravelRequest>>>(result);
            Assert.NotNull(OkObjectResult);
            Assert.True(OkObjectResult.Result is OkObjectResult);

            var travelRequests = Assert.IsAssignableFrom<IEnumerable<TravelRequest>>(((OkObjectResult)OkObjectResult.Result).Value);

            Assert.Equal(objList, travelRequests);
            Assert.Equal(2, travelRequests.Count());

        }

        [Fact]
        public async Task GetTravelRequestById_ActionExecutes_ReturnsOKCategory()
        {
            //Arrange
            _mockRepo.Setup(repo => repo.GetTravelRequestById(2)).ReturnsAsync(objList.ElementAt<TravelRequest>(1));
            //Act
            var result = await _controller.GetTravelRequestById(2);
            //Assert
            Assert.NotNull(result);
            var okObjectResult = Assert.IsType<ActionResult<TravelRequest>>(result);
            Assert.True(okObjectResult.Result is OkObjectResult);
            var tr = Assert.IsType<TravelRequest>(((OkObjectResult)okObjectResult.Result).Value);
            Assert.Equal(objList.ElementAt<TravelRequest>(1).LocFrom, tr.LocFrom);
            Assert.True(objList.ElementAt<TravelRequest>(1).LocFrom == tr.LocFrom);

        }

        [Fact]
        public async Task Create_ActionExecutes_ReturnsOK()
        {
            //Arrange
            TravelRequest tr= new TravelRequest() { RequestId = 1, EmpId = 1, LocFrom = "Pune", LocTo = "Jalgoan", ApprovalStatus = "Pending", BookingStatus = "Pending", CurrentStatus = "Pending" };
            _mockRepo.Setup(repo => repo.AddTravelRequest(It.IsAny<TravelRequest>()));

            //Act
            var result = await _controller.PostTravelRequest(tr);

            //Assert
            Assert.NotNull(result);
            var createObjectResult = Assert.IsAssignableFrom<ActionResult<TravelRequest>>(result);
            Assert.True(createObjectResult is CreatedAtActionResult);
            var tr1 = Assert.IsType<TravelRequest>(((CreatedAtActionResult)createObjectResult.Result).Value);
            Assert.Equal(tr.LocFrom, tr1.LocFrom);
            Assert.True(tr.LocFrom == tr1.LocFrom);
        }

        [Fact]
        public async Task Put_ActionExecutes_ReturnsOK()
        {
            //Arrange
            TravelRequest tr = new TravelRequest() { RequestId = 1, EmpId = 1, LocFrom = "Pune", LocTo = "Jalgoan", ApprovalStatus = "Pending", BookingStatus = "Pending", CurrentStatus = "Pending" };
            _mockRepo.Setup(repo => repo.UpdateTravelRequest( It.IsAny<TravelRequest>(), It.IsAny<int>()));
        }

        [Fact]
        public async Task Delete_ActionExecutes_ReturnsNoContent()
        {
            //Arrange
            _mockRepo.Setup(_ => _.GetTravelRequestById(1)).ReturnsAsync(objList.ElementAt<TravelRequest>(0));
            _mockRepo.Setup(repo => repo.DeleteTravelRequest(It.IsAny<int>()));
            //Act
            var result = await _controller.DeleteTravelRequest(2);
            //Assert
            Assert.NotNull(result);
            var noContentResult = Assert.IsAssignableFrom<ActionResult<TravelRequest>>(result);
            Assert.True(noContentResult is NoContentResult);
            var category = Assert.IsType<NoContentResult>(noContentResult);


        }


        [Fact]
        public async Task Delete_ActionExecutes_ReturnsNotFound()
        {
            //Arrange
            _mockRepo.Setup(repo => repo.DeleteTravelRequest(It.IsAny<int>()));

            //Act
            var result = await _controller.DeleteTravelRequest(3);

            //Assert
           Assert.NotNull(result);
            var notFoundResult = Assert.IsAssignableFrom<ActionResult>(result);
            Assert.True(notFoundResult is NotFoundResult);
            var category = Assert.IsType<NotFoundResult>(notFoundResult);
        }
    }
}
