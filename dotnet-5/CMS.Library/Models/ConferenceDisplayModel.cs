using System;

namespace CMS.BL.Models;

public class ConferenceUserModel
{
    public int Id { get; set; }
    public string Chair { get; set; }
    public string Title { get; set; }
    public string Location { get; set; }
    public DateTime? BeginDate { get; set; }
    public DateTime? EndDate { get; set; }
    public DateTime? PaperDeadline { get; set; }
}
