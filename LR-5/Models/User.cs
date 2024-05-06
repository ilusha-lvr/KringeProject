using System;
using System.Collections.Generic;

namespace LR_5.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string NameP { get; set; } = null!;

    public string Role { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public int? IdUs { get; set; }
}
