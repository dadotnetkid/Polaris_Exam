using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using Data;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Services.Interfaces;
using Services.Validators;

namespace Services.DI
{
    public class AutofacModules : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EmployeeService>().As<IEmployeeService>();
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();
            builder.RegisterType<EmployeeValidator>().As<AbstractValidator<Employees>>();
            builder.RegisterType<EmploymentTypeService>().As<IEmploymentTypeService>();
            builder.RegisterType<PayrollService>().As<IPayrollService>();
            base.Load(builder);
        }
    }
}
