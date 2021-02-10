using System;
using System.Collections.Generic;
using System.Text;
using Data;
using Microsoft.AspNetCore.Http;
using Services.Interfaces;

namespace Services.DI
{
    public class PayrollService : IPayrollService
    {
        private IEmployeeService employeeService;
        private ISession session;

        public PayrollService(IEmployeeService employeeService, IHttpContextAccessor httpContext)
        {
            this.employeeService = employeeService;
            this.session = httpContext.HttpContext.Session;
        }
        public Payrolls GetPayrollDetail(string payrollId)
        {
            throw new NotImplementedException();
        }

        public List<Payrolls> GetPayrolls(string employeeId)
        {
            throw new NotImplementedException();
        }

        public void Insert(Payrolls payrolls)
        {
            throw new NotImplementedException();
        }

        public void Update(Payrolls payrolls)
        {

        }

        public Payrolls Calculate(Payrolls payrolls)
        {
            var emp = employeeService.GetEmployeeDetails(payrolls.EmployeeId);
            if (emp.Type == "Regular")
                payrolls.GrandTotal = calculateRegular(payrolls, emp.Salary);
            else if (emp.Type == "Contractual")
                payrolls.GrandTotal = calculateContractual(payrolls, emp.Salary);
            return payrolls;
        }

        private decimal? calculateRegular(Payrolls payrolls, decimal? monthlySalary)
        {
            var subTotal = ((monthlySalary) - ((monthlySalary / 22) * payrolls.DaysAbsent)) -( monthlySalary* 0.12M);
            return subTotal;
        }
        private decimal? calculateContractual(Payrolls payrolls, decimal? ratePerDay)
        {
            var subTotal = ratePerDay * payrolls.DaysPresent;
            return subTotal;
        }
    }
}
