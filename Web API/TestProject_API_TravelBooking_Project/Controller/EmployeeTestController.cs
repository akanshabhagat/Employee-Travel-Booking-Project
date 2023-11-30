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
    public class EmployeeTestController
    {
        private readonly Mock<IEmployeeRepository> _mockRepo;
        private readonly EmployeeController _controller;
        private IEnumerable<Employee> objList;

        public EmployeeTestController()
        {
            _mockRepo = new Mock<IEmployeeRepository>();
            objList = new List<Employee>()
            {
                new Employee{EmpId = 1, EmpFirstName = "Akansha", EmpLastName = "Bhagat", EmpDob= new DateTime(2002,09,09),  EmpAddress="Pune", EmpContact="9156786788"},
                new Employee{EmpId = 2, EmpFirstName = "Snjali", EmpLastName = "Rajput",EmpDob= new DateTime(2002,09,09), EmpAddress="Pune", EmpContact="9156786788"}
            };

            _mockRepo.Setup(repo => repo.GetEmployees()).ReturnsAsync(objList);
            _controller = new EmployeeController(_mockRepo.Object);
        }
        [Fact]

        public async Task Index_ActionExecutes_ReturnsOkResultForIndex()
        {
            //Act
            var result = await _controller.Get();
            var OkObjectResult = Assert.IsType<ActionResult<IEnumerable<Employee>>>(result);
            Assert.NotNull(OkObjectResult);
            Assert.True(OkObjectResult.Result is OkObjectResult);

            var employees = Assert.IsAssignableFrom<IEnumerable<Employee>>(((OkObjectResult)OkObjectResult.Result).Value);

            Assert.Equal(objList, employees);
            Assert.Equal(2, employees.Count());
            

        }
        [Fact]
        public async Task GetEmployeeById_ActionExecutes_ReturnsOKCategory()
        {
            //Arrange
            _mockRepo.Setup(repo => repo.GetEmployeeById(2)).ReturnsAsync(objList.ElementAt<Employee>(1));
            //Act
            var result = await _controller.GetEmployeeById(2);
            //Assert
            Assert.NotNull(result);
            var createObjectResult = Assert.IsType<ActionResult<Employee>>(result);
            Assert.True(createObjectResult is CreatedAtActionResult);
            var emp = Assert.IsType<Employee>(((CreatedAtActionResult)createObjectResult.Result).Value);
            Assert.Equal(objList.ElementAt<Employee>(1).EmpFirstName, emp.EmpFirstName);
            Assert.True(objList.ElementAt<Employee>(1).EmpFirstName == emp.EmpFirstName);

        }

        [Fact]
        public async Task Create_ActionExecutes_ReturnsOK()
        {
            //Arrange
            Employee emp = new Employee() { EmpId = 3, EmpFirstName = "Janvi", EmpLastName = "Kapoor", EmpDob = new DateTime(2002, 09, 09), EmpAddress = "Banglore", EmpContact = "9156786788" };
            _mockRepo.Setup(repo => repo.AddEmployee(It.IsAny<Employee>()));

            //Act
            var result = await _controller.PostEmployee(emp);

            //Assert
            Assert.NotNull(result);
            var createObjectResult = Assert.IsAssignableFrom<ActionResult<Employee>>(result);
            Assert.True(createObjectResult is CreatedAtActionResult);
            var emp1 = Assert.IsType<Employee>(((CreatedAtActionResult)createObjectResult.Result).Value);
            Assert.Equal(emp.EmpFirstName, emp1.EmpFirstName);
            Assert.True(emp.EmpFirstName == emp1.EmpFirstName);
        }

        [Fact]
        public async Task Put_ActionExecutes_ReturnsOK()
        {
            //Arrange
            Employee emp = new Employee() { EmpId = 3, EmpFirstName = "Janvi", EmpLastName = "Kappoor", EmpAddress = "Banglore", EmpContact = "9156786788" };
            _mockRepo.Setup(repo => repo.UpdateEmployee( It.IsAny<Employee>(), It.IsAny<int>()));
        }

        [Fact]
        public async Task Delete_ActionExecutes_ReturnsNoContent()
        {
            //Arrange
            _mockRepo.Setup(_ => _.GetEmployeeById(1)).ReturnsAsync(objList.ElementAt<Employee>(0));
            _mockRepo.Setup(repo => repo.DeleteEmployee(It.IsAny<int>()));
            //Act
            var result = await _controller.DeleteEmployee(1);
            //Assert
            Assert.NotNull(result);
            var noContentResult = Assert.IsAssignableFrom<ActionResult<Employee>>(result);
            Assert.True(noContentResult is NoContentResult);
            var category = Assert.IsType<NoContentResult>(noContentResult);


        }


        [Fact]
        public async Task Delete_ActionExecutes_ReturnsNotFound()
        {
            //Arrange
            _mockRepo.Setup(repo => repo.DeleteEmployee(It.IsAny<int>()));

            //Act
            var result = await _controller.DeleteEmployee(2);

            //Assert
            Assert.NotNull(result);
            var notFoundResult = Assert.IsAssignableFrom<ActionResult>(result);
            Assert.True(notFoundResult is NotFoundResult);
            var category = Assert.IsType<NotFoundResult>(notFoundResult);
        }
    }
}

