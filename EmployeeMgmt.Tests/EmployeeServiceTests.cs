using EmployeeMgmt.Application.DTOs;
using EmployeeMgmt.Application.Interfaces;
using EmployeeMgmt.Application.Services;
using EmployeeMgmt.Domain.Entities;
using EmployeeMgmt.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeMgmt.Tests
{
    public class EmployeeServiceTests
    {
        private readonly IEmployeeService _employeeService;
        private readonly Mock<IEmployeeRepository> _mockRepo;

        public EmployeeServiceTests()
        {
            _mockRepo = new Mock<IEmployeeRepository>();
        }

        [Fact]
        public async Task GetAllEmployeesAsync_ReturnsAllEmployees()
        {
           
            var employees = new List<Employee>
            {
                new Employee { EmployeeId = Guid.NewGuid(), Name = "Mohamed Basheer", Email = "basheer@gmail.com" },
                new Employee { EmployeeId = Guid.NewGuid(), Name = "Haleema Shabnam", Email = "haleema@gmail.com" }
            };

            _mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(employees);

            
            var result = await _employeeService.GetAllEmployeesAsync();

            
            Assert.Equal(employees, (IAsyncEnumerable<Employee>?)result);
        }

        [Fact]
        public async Task CreateEmployeeAsync_AddsEmployee()
        {
          
            var employeeDto = new EmployeeDto { Name = "Mohamed Basheer", Email = "basheer@gmail.com" };
            var employee = new Employee { EmployeeId = Guid.NewGuid(), Name = employeeDto.Name, Email = employeeDto.Email };

            _mockRepo.Setup(repo => repo.AddAsync(It.IsAny<Employee>())).Returns(Task.CompletedTask);

           
            await _employeeService.CreateEmployeeAsync(employeeDto);

           
            _mockRepo.Verify(repo => repo.AddAsync(It.IsAny<Employee>()), Times.Once);
        }

       
    }
}
