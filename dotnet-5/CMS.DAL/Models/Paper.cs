using System;
using System.Collections.Generic;

namespace CMS.DAL.Models;

public partial class Paper
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Author { get; set; }

    public DateTime SubmissionDate { get; set; }

    public string Length { get; set; }

    public byte[] Content { get; set; }

    public int ConferenceId { get; set; }

    public int AuthorId { get; set; }

    public string Format { get; set; }

    public string Status { get; set; }

    public string FileName { get; set; }

    public virtual User AuthorNavigation { get; set; }

    public virtual Conference Conference { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; } = new List<Feedback>();

    public virtual ICollection<PaperReview> PaperReviews { get; } = new List<PaperReview>();

    public virtual ICollection<PaperTopic> PaperTopics { get; } = new List<PaperTopic>();
}
