using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Delarue.JB.Entities;
using StructureMap;

namespace Delarue.JB.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DbContext context)
            : base(context)
        {
        }

        public IQueryable<Employee> GetByName(string name)
        {
            return DbSet.Where(x => x.Name == name);
        }

        public Employee GetByEmployeeCode(int code)
        {
            return DbSet.Where(x => x.EmployeeCode == code).FirstOrDefault();
        }

        public IQueryable<Employee> GetByStartDate(DateTime startDate)
        {
            return DbSet.Where(x => x.StartDate == startDate);
        }
    }
}