using BusinessLogic;
using DataAccessors.Accessors;
using DataAccessors.Entity;
using Ninject;
using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using WebClient.Models;

namespace WebClient
{
    public class Global : System.Web.HttpApplication
    {
        public static IKernel NinjectKernel;
        public static Logger Logger;

        protected void Application_Start(object sender, EventArgs e)
        {
            Global.Logger = LogManager.GetCurrentClassLogger();
            Global.Logger.Trace("App start");

            NinjectKernel = new StandardKernel();

            

            string accessorType = ConfigurationManager.AppSettings.Get("AccessorType");
            string appConfigConnectionString = "ServiceDb";

            string fileDbHome = ConfigurationManager.AppSettings.Get("FileDbHome");
            string directoryDbHome = ConfigurationManager.AppSettings.Get("DirectoryDbHome");

            string appDataFolder = AppDomain.CurrentDomain.GetData("DataDirectory") as string;
            fileDbHome = fileDbHome.Replace("|DataDirectory|", appDataFolder);
            directoryDbHome = directoryDbHome.Replace("|DataDirectory|", appDataFolder);

            switch (accessorType)
            {
                case "orm":
                    NinjectKernel.Bind<IAccessor<Person>>().To<OrmPersonAccessor>().InSingletonScope().WithConstructorArgument<string>(appConfigConnectionString);
                    NinjectKernel.Bind<IAccessor<Phone>>().To<OrmPhoneAccessor>().InSingletonScope().WithConstructorArgument<string>(appConfigConnectionString);
                    break;
                case "ado":
                    NinjectKernel.Bind<IAccessor<Person>>().To<ADOPersonAccessor>().InSingletonScope().WithConstructorArgument<string>(appConfigConnectionString);
                    NinjectKernel.Bind<IAccessor<Phone>>().To<ADOPhoneAccessor>().InSingletonScope().WithConstructorArgument<string>(appConfigConnectionString);
                    break;
                case "dir":
                    NinjectKernel.Bind<IAccessor<Person>>().To<DirectoryPersonAccessor>().InSingletonScope().WithConstructorArgument<string>(directoryDbHome + @"\Persons");
                    NinjectKernel.Bind<IAccessor<Phone>>().To<DirectoryPhoneAccessor>().InSingletonScope().WithConstructorArgument<string>(directoryDbHome + @"\Phone");
                    break;
                case "file":
                    NinjectKernel.Bind<IAccessor<Person>>().To<DirectoryPersonAccessor>().InSingletonScope().WithConstructorArgument<string>(fileDbHome + @"\FilePersonDb.xml");
                    NinjectKernel.Bind<IAccessor<Phone>>().To<DirectoryPhoneAccessor>().InSingletonScope().WithConstructorArgument<string>(fileDbHome + @"\FilePhoneDb.xml");
                    break;
                case "mem":
                    break;
            }
            NinjectKernel.Bind<IPersonBll>().To<PersonBll>().InSingletonScope();
            NinjectKernel.Bind<IPhoneBll>().To<PhoneBll>().InSingletonScope();

        }
    }
}