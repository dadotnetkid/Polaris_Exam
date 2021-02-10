using System;
using System.Collections.Generic;
using System.Text;
using Data;
using FluentValidation;
using Services.Interfaces;

namespace Services.Validators
{
    public class EmployeeValidator : AbstractValidator<Employees>
    {
        private IEmployeeService employeeService;

        public EmployeeValidator(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;

            RuleFor(x => x.TIN)
                .NotEmpty().WithMessage("TIN is required")
                .Must(CheckIfExist).WithMessage("TIN is exist");
            RuleFor(x => x.EmployeeName)
                .NotEmpty().WithMessage("Employee name is required");
            RuleFor(x => x.BirthDate)
                .NotEmpty().WithMessage("Birth Date is required");
            RuleFor(x => x.Salary)
                .NotEmpty().WithMessage("Salary is required");
            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("Employment Type is required");

        }

        private bool CheckIfExist(Employees arg1, string arg2)
        {
            if (!string.IsNullOrEmpty( arg1.Id ))
                return true;    
            return !employeeService.CheckIfExist(arg2);
        }
    }
}
