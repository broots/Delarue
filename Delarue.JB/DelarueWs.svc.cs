using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Delarue.JB.Entities;
using Delarue.JB.Repositories;
using StructureMap;

namespace Delarue.JB
{
    public class DelarueWs : IDelarueWs
    {
        private IEmployeeRepository employeeRepository;

        public DelarueWs()
        {
            employeeRepository = ObjectFactory.GetInstance<IEmployeeRepository>(); // new EmployeeRepository(new DelarueContext());
        }

        public void AddEmployee(Employee employee)
        {
            employeeRepository.Insert(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            employeeRepository.Delete(employee);
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return employeeRepository.GetAll();
        }

        public IEnumerable<Employee> GetEmployeesByName(string name)
        {
            return employeeRepository.GetByName(name);
        }

        public Employee GetEmployeeByCode(int employeeCode)
        {
            return employeeRepository.GetByEmployeeCode(employeeCode);
        }

        public IEnumerable<Employee> GetEmployeesByStartDate(DateTime startDate)
        {
            return employeeRepository.GetByStartDate(startDate);
        }
    }
}
