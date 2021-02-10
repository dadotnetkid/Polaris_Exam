using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Services.Helper;
using Services.Interfaces;
using Services.ViewModels;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeService employeeService;
        private IPayrollService payrollService;

        public HomeController(IEmployeeService employeeService, IPayrollService payrollService)
        {
            this.employeeService = employeeService;
            this.payrollService = payrollService;

        }

        public IActionResult Index()
        {
            //populate test for grid
            employeeService.InitialData();
            return View();
        }

        public IActionResult EmployeePartial()
        {
            return PartialView(employeeService.GetEmployees());
        }

        public IActionResult EmployeeDetailPartial(Employees employees)
        {
            return PartialView(employeeService.GetEmployeeDetails(employees.Id));
        }

        public IActionResult AddEditEmployeePartial(Employees employees)
        {
            if (!ModelState.IsValid)
                return PartialView("EmployeeDetailPartial", employees);
            if (string.IsNullOrEmpty(employees.Id))
                employeeService.Insert(employees);
            else
                employeeService.Update(employees);
            return Json(new { isSuccess = true });
        }

        public IActionResult DeleteEmployeePartial(string employeeId)
        {
            try
            {
                employeeService.Delete(employeeId);
                return Json(new { isSuccess = true });
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });
            }

        }

        public IActionResult CalculatePayrollPartial(string employeeId)
        {
            return PartialView(new EmployeeViewModel()
            {
                Employees = this.employeeService.GetEmployeeDetails(employeeId),
                Payrolls = new Payrolls()
            });
        }
        [HttpPost]
        public IActionResult CalculatePayrollPartial(EmployeeViewModel model)
        {
            var employee = this.employeeService.GetEmployeeDetails(model.EmployeeId);
            model.Employees = employee;
            model.Payrolls.EmployeeId = model.EmployeeId;
            model.Payrolls = this.payrollService.Calculate(model.Payrolls);
            return PartialView(model);
        }
    }
}
