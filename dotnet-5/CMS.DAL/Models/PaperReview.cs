﻿using System;
using System.Collections.Generic;

#nullable disable

namespace CMS.DAL.Models;

public partial class PaperReview
{
    public int Id { get; set; }
    public int PaperId { get; set; }
    public int UserId { get; set; }
    public int? PaperRating { get; set; }

    public virtual Paper Paper { get; set; }
    public virtual User User { get; set; }
}
