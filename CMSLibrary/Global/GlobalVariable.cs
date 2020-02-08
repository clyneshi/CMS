using CMSLibrary.Model;

namespace CMSLibrary.Global
{
    public class GlobalVariable
    {
        public static int UserConference { get; internal set; } = 0;
        public static User CurrentUser { get; internal set; }
        
        internal static readonly CMSDBEntities DbModel = new CMSDBEntities();
    }
}
