using System;
using System.Data.Entity;
using System.Linq;
using Delarue.JB.Entities;
using Delarue.JB.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;
using System.Data.Entity.Infrastructure;

namespace Delarue.JB.Tests
{
    [TestClass]
    public class DelarueTests
    {
        IEmployeeRepository er;

        DbContext dbContext;

        Employee emp;
        Employee empToAddDelete;

        public DelarueTests()
        {
            Database.SetInitializer(new DelarueContextDbInitializer());

            IContainer container = SetupDependencies();
            er = container.GetInstance<IEmployeeRepository>();
            dbContext = container.GetInstance<DbContext>();

            emp = new Employee() { Name = "Fred Smith", EmployeeCode = 10001, StartDate = DateTime.Parse("01 Jan 2010") };
        }

        [TestMethod]
        public void GetAll_Test()
        {
            var actual = er.GetAll();

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count() > 0);
        }

        [TestMethod]
        public void GetByNameReturnsResult_Test()
        {
            string empName = emp.Name;

            var expected = emp;

            var actual = er.GetByName(empName);

            Assert.IsTrue(actual.Select(x => x.Name).Contains(empName));
            Assert.IsFalse(actual.Select(x => x.Name).Contains("Joe Bloggs"));
        }

        [TestMethod]
        public void GetByEmployeeCodeReturnsResult_Test()
        {
            var empCode = emp.EmployeeCode;
            var expected = emp;

            var actual = er.GetByEmployeeCode(empCode);

            Assert.IsTrue(expected.Name.Equals(actual.Name, StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void GetByStartDateReturnsResult_Test()
        {
            var startDate = emp.StartDate;
            var expected = emp;
            var actual = er.GetByStartDate(startDate);

            Assert.IsTrue(actual.Select(x => x.EmployeeCode).Contains(expected.EmployeeCode));
        }

        private IContainer SetupDependencies()
        {
            return new Container(x =>
            {
                x.For<DbContext>().Use(() => new DbContext("DelarueDb"));
                x.For<DelarueContext>().Use(() => new DelarueContext());
                x.For<IEmployeeRepository>().Use(() => new EmployeeRepository(ObjectFactory.GetInstance<DelarueContext>()));
            });
        }
    }
}
