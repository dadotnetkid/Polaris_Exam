using System.Collections.Generic;
using Data;

namespace Services.Interfaces
{
    public interface IEmploymentTypeService
    {
        public List<EmploymentTypes> GetEmploymentTypes();
    }
}
