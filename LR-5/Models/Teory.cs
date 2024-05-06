using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LR_5.Models;

public partial class Teory
{
    [Key]
    public int Id { get; set; }

    public int GroupId { get; set; }

    public DateOnly DateL { get; set; }

    public TimeOnly TimeL { get; set; }

    public virtual Group Group { get; set; } = null!;
}
