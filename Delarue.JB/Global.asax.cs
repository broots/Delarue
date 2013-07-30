using StructureMap;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Delarue.JB.Repositories;
using Delarue.JB.Entities;
using System.Data.Entity.Infrastructure;

namespace Delarue.JB
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Database.SetInitializer(new DelarueContextDbInitializer());

            ObjectFactory.Configure(config =>
            {
                config.Scan(scan =>
                {
                    scan.LookForRegistries();
                });

                config.For<IObjectContextAdapter>().Use(() => new DbContext("DelarueDb"));
                config.For<DelarueContext>().Use(() => new DelarueContext());

                config.For<IRepository<Employee>>().Use<Repository<Employee>>();
                config.For<IEmployeeRepository>().Use(() => new EmployeeRepository(ObjectFactory.GetInstance<DelarueContext>()));
            });
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}