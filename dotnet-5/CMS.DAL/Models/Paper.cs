using System;
using System.Collections.Generic;

#nullable disable

namespace CMS.DAL.Models;

public partial class Paper
{
    public Paper()
    {
        Feedbacks = new HashSet<Feedback>();
        PaperReviews = new HashSet<PaperReview>();
        PaperTopics = new HashSet<PaperTopic>();
    }

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
    public virtual ICollection<Feedback> Feedbacks { get; set; }
    public virtual ICollection<PaperReview> PaperReviews { get; set; }
    public virtual ICollection<PaperTopic> PaperTopics { get; set; }
}
