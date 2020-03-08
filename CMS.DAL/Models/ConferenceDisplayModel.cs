using System;

namespace CMS.Library.Model
{
    public class ConferenceUserModel
    {
        public int Id { get; set; }
        public string Chair { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public Nullable<System.DateTime> BeginDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<System.DateTime> PaperDeadline { get; set; }
    }
}
