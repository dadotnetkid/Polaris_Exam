using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class Payrolls
    {
        public string Id { get; set; }
        public string EmployeeId { get; set; }
        public decimal? DaysPresent { get; set; }
        public decimal? DaysAbsent { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? GrandTotal { get; set; }
    }
}
