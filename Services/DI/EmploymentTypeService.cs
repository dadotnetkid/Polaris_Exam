using System;
using System.Collections.Generic;
using System.Text;
using Data;
using Services.Interfaces;

namespace Services.DI
{
    public class EmploymentTypeService : IEmploymentTypeService
    {
        public List<EmploymentTypes> GetEmploymentTypes()
        {
            return new List<EmploymentTypes>() {
                new EmploymentTypes (){ EmploymentType="Regular"},
                new EmploymentTypes(){EmploymentType="Contractual"}

            };
        }
    }
}
