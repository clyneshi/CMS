using System;
using System.Collections.Generic;

namespace CMS.DAL.Models;

public partial class RegisterRequest
{
    public int Id { get; set; }

    public int? ConferenceId { get; set; }

    public string Name { get; set; }

    public string Password { get; set; }

    public string Contact { get; set; }

    public string Email { get; set; }

    public string Status { get; set; }

    public int RoleId { get; set; }

    public virtual Conference Conference { get; set; }

    public virtual Role Role { get; set; }
}
