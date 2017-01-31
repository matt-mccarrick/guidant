using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuidantHomework.Core.Repositories;
using GuidantHomework.Core.Services;
using GuidantHomework.Data.Repositories;
using GuidantHomework.Services;
using Microsoft.Practices.Unity;

namespace GuidantHomework.IoC
{
    public class GuidantHomeworkContainerBootstrapper
    {
        public static IUnityContainer RegisterTypes(IUnityContainer container)
        {
            //Register Repos
            container.RegisterType<IUserRepository>(new InjectionFactory((c, t, s) => new UserRepository()));
            //Register Services
            container.RegisterType<IUserService>(new InjectionFactory((c, t, s) => new UserService(
                container.Resolve<IUserRepository>()
                )));

            return container;
        }
    }
}
