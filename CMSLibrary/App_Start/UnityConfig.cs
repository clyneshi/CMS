using CMSLibrary.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace CMSLibrary.App_Start
{
    public class UnityConfig
    {
        public static IUnityContainer UnitySetup()
        {
            var container = new UnityContainer();
            container.RegisterType<IUserService, UserService>();
            return container;
        }
    }
}
