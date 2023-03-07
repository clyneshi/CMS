using System;
using System.Collections.Generic;

#nullable disable

namespace CMS.DAL.Models;

public partial class ConferenceTopic
{
    public int Id { get; set; }
    public int ConferenceId { get; set; }
    public int KeywordId { get; set; }

    public virtual Conference Conference { get; set; }
    public virtual Keyword Keyword { get; set; }
}
