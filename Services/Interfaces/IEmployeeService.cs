using System;
using System.Collections.Generic;
using System.Text;
using Data;

namespace Services.Interfaces
{
    public interface IEmployeeService
    {
        public List<Employees> GetEmployees();
        public Employees GetEmployeeDetails(string employeeId);
        public void Insert(Employees employees);
        public void Update(Employees employees);
        public void Delete(string employeeId);
        public void Calculate(Employees employees);
        public void InitialData();
        public bool CheckIfExist(string Tin);

    }
}
