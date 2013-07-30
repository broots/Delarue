using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Delarue.JB.Entities;

namespace Delarue.JB
{
    public class DelarueContextDbInitializer : DropCreateDatabaseAlways<DelarueContext> 
    {
        protected override void Seed(DelarueContext context)
        {
            base.Seed(context);
            context.Employees.Add(new Employee() { Name = "Fred Smith", EmployeeCode = 10001, StartDate = DateTime.Parse("01 Jan 2010") });
        }
    }
}