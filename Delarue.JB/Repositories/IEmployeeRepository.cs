using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delarue.JB.Entities;

namespace Delarue.JB.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        /// <summary>
        /// Gets the name of the by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>List of employees</returns>
        IQueryable<Employee> GetByName(string name);

        /// <summary>
        /// Gets the by employee code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>Employee object</returns>
        Employee GetByEmployeeCode(int code);

        /// <summary>
        /// Gets the by start date.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <returns>List of employess</returns>
        IQueryable<Employee> GetByStartDate(DateTime startDate);
    }
}
