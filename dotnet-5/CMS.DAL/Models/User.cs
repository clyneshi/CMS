using System;
using System.Collections.Generic;

namespace CMS.DAL.Models;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; }

    public string Name { get; set; }

    public string Password { get; set; }

    public string Contact { get; set; }

    public int RoleId { get; set; }

    public virtual ICollection<ConferenceMember> ConferenceMembers { get; } = new List<ConferenceMember>();

    public virtual ICollection<Conference> Conferences { get; } = new List<Conference>();

    public virtual ICollection<Expertise> Expertises { get; } = new List<Expertise>();

    public virtual ICollection<Feedback> Feedbacks { get; } = new List<Feedback>();

    public virtual ICollection<PaperReview> PaperReviews { get; } = new List<PaperReview>();

    public virtual ICollection<Paper> Papers { get; } = new List<Paper>();

    public virtual Role Role { get; set; }
}
