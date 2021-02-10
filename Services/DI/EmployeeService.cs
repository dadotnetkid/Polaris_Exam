using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using Microsoft.AspNetCore.Http;
using Services.Helper;
using Services.Interfaces;
using Microsoft.AspNetCore.Session;
namespace Services.DI
{
    public class EmployeeService : IEmployeeService
    {
        private IHttpContextAccessor httpContext;
        private ISession session;


        public EmployeeService(IHttpContextAccessor httpContext)
        {
            this.httpContext = httpContext;
            this.session = httpContext.HttpContext.Session;
        }
        public List<Employees> GetEmployees()
        {
            try
            {
                var res = session?.GetComplexData<List<Employees>>("Employees");

                return res;
            }
            catch (Exception e)
            {
                return new List<Employees>();
            }

        }

        public Employees GetEmployeeDetails(string employeeId)
        {
            var res = session.GetComplexData<List<Employees>>("Employees");
            var employee = res.FirstOrDefault(x => x.Id == employeeId);

            return employee;
        }

        public void Insert(Employees employees)
        {
            try
            {
                var res = session.GetComplexData<List<Employees>>("Employees");
                employees.Id = Guid.NewGuid().ToString();
                res.Add(employees);
                session.SetComplexData("Employees", res);
            }
            catch (Exception e)
            {

            }
        }

        public void Update(Employees employees)
        {
            try
            {
                var res = session.GetComplexData<List<Employees>>("Employees");
                res.Remove(res.FirstOrDefault(x => x.Id == employees.Id));
                res.Add(employees);
                session.SetComplexData("Employees", res);
            }
            catch (Exception e)
            {

            }
        }

        public void Delete(string employeeId)
        {
            var res = session.GetComplexData<List<Employees>>("Employees");
            res.Remove(res.FirstOrDefault(x => x.Id == employeeId));
            session.SetComplexData("Employees", res);
        }

        public void Calculate(Employees employees)
        {
            throw new NotImplementedException();
        }

        public void InitialData()
        {
            if (session.IsNotEmpty("Employees"))
                return;

            session.SetComplexData("Employees", new List<Employees>() { new Employees() {
                Id = Guid.NewGuid().ToString(),
                EmployeeName = "Mark Cacal",
                BirthDate = DateTime.Now,
                TIN = "00000",
                Salary=20000,
                Type = "Regular"
            } });
        }

        public bool CheckIfExist(string tin)
        {
            var res = session.GetComplexData<List<Employees>>("Employees");
            return res.Any(x => x.TIN.ToLower() == tin?.ToLower());
        }

    }
}
