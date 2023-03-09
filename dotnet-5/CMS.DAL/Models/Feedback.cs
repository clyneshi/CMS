using System;
using System.Collections.Generic;

namespace CMS.DAL.Models;

public partial class Feedback
{
    public int Id { get; set; }

    public int PaperId { get; set; }

    public int UserId { get; set; }

    public string FinalDecision { get; set; }

    public string Comments { get; set; }

    public virtual Paper Paper { get; set; }

    public virtual User User { get; set; }
}
