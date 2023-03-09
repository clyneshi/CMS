using System;
using System.Collections.Generic;

namespace CMS.DAL.Models;

public partial class Keyword
{
    public int Id { get; set; }

    public string Genre { get; set; }

    public string Name { get; set; }

    public virtual ICollection<ConferenceTopic> ConferenceTopics { get; } = new List<ConferenceTopic>();

    public virtual ICollection<Expertise> Expertises { get; } = new List<Expertise>();

    public virtual ICollection<PaperTopic> PaperTopics { get; } = new List<PaperTopic>();
}
