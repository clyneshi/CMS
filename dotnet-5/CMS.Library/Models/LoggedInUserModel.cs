using CMS.DAL.Models;

namespace CMS.BL.Models
{
    public class LoggedInUserModel
    {
        public User User { get; }
        public int? ConferenceId { get; }

        public LoggedInUserModel(User user, int? conferenceId)
        {
            User = user;
            ConferenceId = conferenceId;
        }
    }
}
