using System;
using System.Collections.Generic;

namespace LR_5.Models;

public partial class Stud
{
    //public int Id { get; set; }

    public int StudId { get; set; }

    public int CatId { get; set; }

    public int InstId { get; set; }

    public string Surname { get; set; } = null!;

    public string NameS { get; set; } = null!;

    public string Otchestvo { get; set; } = null!;

    public DateOnly DateS { get; set; }

    public DateOnly? DateE { get; set; }

    public bool Exam { get; set; }

    public virtual Category Cat { get; set; } = null!;

    public virtual Instruct Inst { get; set; } = null!;

    public virtual ICollection<Rec> Recs { get; set; } = new List<Rec>();
}
