using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CMS.DAL.Models;

public partial class Role
{
    public Role()
    {
        RegisterRequests = new HashSet<RegisterRequest>();
        Users = new HashSet<User>();
    }

    public int Id { get; set; }
    public string Type { get; set; }

    public virtual ICollection<RegisterRequest> RegisterRequests { get; set; }
    public virtual ICollection<User> Users { get; set; }
}
