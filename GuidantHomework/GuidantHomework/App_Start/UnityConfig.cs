using Microsoft.Practices.Unity;
using System.Web.Http;
using GuidantHomework.IoC;
using Unity.WebApi;

namespace GuidantHomework
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            GuidantHomeworkContainerBootstrapper.RegisterTypes(container);


            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}