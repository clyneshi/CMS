using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CMS.DAL.Models
{
    public partial class Keyword
    {
        public Keyword()
        {
            ConferenceTopics = new HashSet<ConferenceTopic>();
            Expertises = new HashSet<Expertise>();
            PaperTopics = new HashSet<PaperTopic>();
        }

        public int Id { get; set; }
        public string Genre { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ConferenceTopic> ConferenceTopics { get; set; }
        public virtual ICollection<Expertise> Expertises { get; set; }
        public virtual ICollection<PaperTopic> PaperTopics { get; set; }
    }
}
