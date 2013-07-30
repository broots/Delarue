using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Delarue.JB.Entities;

namespace Delarue.JB
{
    [ServiceContract]
    public interface IDelarueWs
    {
        [OperationContract]
        void AddEmployee(Employee employee);

        [OperationContract]
        void DeleteEmployee(Employee employee);

        [OperationContract]
        IEnumerable<Employee> GetAllEmployees();

        [OperationContract]
        IEnumerable<Employee> GetEmployeesByName(string name);

        [OperationContract]
        Employee GetEmployeeByCode(int employeeCode);

        [OperationContract]
        IEnumerable<Employee> GetEmployeesByStartDate(DateTime startDate);
    }
}
