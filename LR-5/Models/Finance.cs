using System;
using System.Collections.Generic;

namespace LR_5.Models;

public partial class Finance
{
    public int StudId { get; set; }

    public int CatId { get; set; }

    public decimal SumVn { get; set; }

    public string TypePay { get; set; } = null!;

    public virtual Category Cat { get; set; } = null!;

    public virtual Stud Stud { get; set; } = null!;
}
