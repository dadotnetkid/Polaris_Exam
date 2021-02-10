using System.Collections.Generic;
using Data;

namespace Services.Interfaces
{
    public interface IPayrollService
    {

        Payrolls GetPayrollDetail(string payrollId);
        List<Payrolls> GetPayrolls(string employeeId);
        void Insert(Payrolls payrolls);
        void Update(Payrolls payrolls);
        Payrolls Calculate(Payrolls payrolls);
    }
}
