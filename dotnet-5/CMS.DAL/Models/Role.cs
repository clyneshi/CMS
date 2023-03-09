using System;
using System.Collections.Generic;

namespace CMS.DAL.Models;

public partial class Role
{
    public int Id { get; set; }

    public string Type { get; set; }

    public virtual ICollection<RegisterRequest> RegisterRequests { get; } = new List<RegisterRequest>();

    public virtual ICollection<User> Users { get; } = new List<User>();
}
