using System;
using System.Collections.Generic;

namespace CMS.DAL.Models;

public partial class ConferenceMember
{
    public int Id { get; set; }

    public int ConferenceId { get; set; }

    public int UserId { get; set; }

    public virtual Conference Conference { get; set; }

    public virtual User User { get; set; }
}
