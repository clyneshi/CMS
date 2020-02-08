using CMS.Library.Service;
using Unity;

namespace CMS.Library.App_Start
{
    public class UnityConfig
    {
        public static IUnityContainer UIContainer;

        public static void TypeRegister()
        {
            var container = new UnityContainer();
            container.RegisterType<IConferenceService, ConferenceService>();
            container.RegisterType<IKeywordService, KeywordService>();
            container.RegisterType<IPaperService, PaperService>();
            container.RegisterType<IRoleService, RoleService>();
            container.RegisterType<IUserRequestService, UserRequestService>();
            container.RegisterType<IUserService, UserService>();

            UIContainer = container;
        }
    }
}
