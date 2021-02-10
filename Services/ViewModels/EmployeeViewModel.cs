using System;
using System.Collections.Generic;
using System.Text;
using Data;

namespace Services.ViewModels
{
 public   class EmployeeViewModel
    {
        public Employees Employees { get; set; }
        public Payrolls Payrolls { get; set; }
        public string EmployeeId { get; set; }
    }
}
