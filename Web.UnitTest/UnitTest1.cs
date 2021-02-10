using Data;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Services.Interfaces;
using Web.Controllers;

namespace Web.UnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var employee = new Mock<IEmployeeService>();
            employee.Setup(s => s.GetEmployees());
            var payroll = new Mock<IPayrollService>();
            var controller = new HomeController(employee.Object,payroll.Object);
            var result =  controller.EmployeePartial();
            Assert.IsInstanceOf<PartialViewResult>(result);


 
            Assert.Pass();
        }
    }
} 