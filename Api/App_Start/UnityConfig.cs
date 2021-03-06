using Api.Framework;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IMongoContext, MongoContext>(new ContainerControlledLifetimeManager());
            container.RegisterType<ILedgerHelper, LedgerHelper>(new ContainerControlledLifetimeManager());
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}