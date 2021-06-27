using System;
using System.Collections.Generic;

#nullable disable

namespace CMS.DAL.Models
{
    public partial class Conference
    {
        public Conference()
        {
            ConferenceMembers = new HashSet<ConferenceMember>();
            ConferenceTopics = new HashSet<ConferenceTopic>();
            Papers = new HashSet<Paper>();
            RegisterRequests = new HashSet<RegisterRequest>();
        }

        public int Id { get; set; }
        public int ChairId { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime PaperDeadline { get; set; }

        public virtual User Chair { get; set; }
        public virtual ICollection<ConferenceMember> ConferenceMembers { get; set; }
        public virtual ICollection<ConferenceTopic> ConferenceTopics { get; set; }
        public virtual ICollection<Paper> Papers { get; set; }
        public virtual ICollection<RegisterRequest> RegisterRequests { get; set; }
    }
}
