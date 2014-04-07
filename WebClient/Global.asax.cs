using DataAccessors.Accessors;
using DataAccessors.Data;
using DataAccessors.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace WebClient
{
    public class Global : System.Web.HttpApplication
    {
        public static IDictionary<string, IAccessor<Person>> Accessors = new Dictionary<string, IAccessor<Person>>();

        protected void Application_Start(object sender, EventArgs e)
        {
            string appConfigConnectionString = "ServiceDB";                                    
            Accessors.Add("orm", new OrmPersonAccessor(appConfigConnectionString));
            Accessors.Add("ado", new ADOPersonAccessor(appConfigConnectionString));
            Accessors.Add("file", new FilePersonAccessor(@"C:\Users\pc-1\Desktop\MyOrm\DataProject\bin\Debug\Data\FilePersonDB.txt"));
            Accessors.Add("dir", new DirectoryPersonAccessor(@"C:\Users\pc-1\Desktop\MyOrm\DataProject\bin\Debug\Data\FolderDBb"));
            Accessors.Add("mem", new MemoryPersonAccessor());

            //RouteCollection
            RouteTable.Routes.MapPageRoute("1", "Persons", "~/PersonList.aspx");
            RouteTable.Routes.MapPageRoute("2", "Persons/{test}", "~/PersonList.aspx");
            RouteTable.Routes.MapPageRoute("3", "", "~/PersonList.aspx");
            
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