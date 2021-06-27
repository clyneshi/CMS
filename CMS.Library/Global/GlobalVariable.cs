using CMS.DAL.Models;

namespace CMS.Service.Global
{
    public class GlobalVariable
    {
        public static int UserConference { get; internal set; } = 0;
        public static User CurrentUser { get; internal set; }
    }
}
