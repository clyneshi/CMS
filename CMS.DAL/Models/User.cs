using System;
using System.Collections.Generic;

#nullable disable

namespace CMS.DAL.Models
{
    public partial class User
    {
        public User()
        {
            ConferenceMembers = new HashSet<ConferenceMember>();
            Conferences = new HashSet<Conference>();
            Expertises = new HashSet<Expertise>();
            Feedbacks = new HashSet<Feedback>();
            PaperReviews = new HashSet<PaperReview>();
            Papers = new HashSet<Paper>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Contact { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<ConferenceMember> ConferenceMembers { get; set; }
        public virtual ICollection<Conference> Conferences { get; set; }
        public virtual ICollection<Expertise> Expertises { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<PaperReview> PaperReviews { get; set; }
        public virtual ICollection<Paper> Papers { get; set; }
    }
}
