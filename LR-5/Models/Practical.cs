﻿using System;
using System.Collections.Generic;

namespace LR_5.Models;

public partial class Practical
{
    public int RecId { get; set; }

    public int StudId { get; set; }

    public int InstId { get; set; }

    public int CarId { get; set; }

    public DateOnly DateL { get; set; }

    public TimeOnly TimeL { get; set; }

    public virtual Car Car { get; set; } = null!;

    public virtual Instruct Inst { get; set; } = null!;

    public virtual Rec Rec { get; set; } = null!;

    public virtual Stud Stud { get; set; } = null!;
}
