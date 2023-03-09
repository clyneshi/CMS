using System;
using System.Collections.Generic;

namespace CMS.DAL.Models;

public partial class Conference
{
    public int Id { get; set; }

    public int ChairId { get; set; }

    public string Title { get; set; }

    public string Location { get; set; }

    public DateTime BeginDate { get; set; }

    public DateTime EndDate { get; set; }

    public DateTime PaperDeadline { get; set; }

    public virtual User Chair { get; set; }

    public virtual ICollection<ConferenceMember> ConferenceMembers { get; } = new List<ConferenceMember>();

    public virtual ICollection<ConferenceTopic> ConferenceTopics { get; } = new List<ConferenceTopic>();

    public virtual ICollection<Paper> Papers { get; } = new List<Paper>();

    public virtual ICollection<RegisterRequest> RegisterRequests { get; } = new List<RegisterRequest>();
}
