using System;
using System.Collections.Generic;

namespace CMS.DAL.Models;

public partial class PaperTopic
{
    public int Id { get; set; }

    public int PaperId { get; set; }

    public int KeywordId { get; set; }

    public virtual Keyword Keyword { get; set; }

    public virtual Paper Paper { get; set; }
}
