using System;
using System.Collections.Generic;

namespace LR_5.Models;

public partial class Instruct
{
    public int InstId { get; set; }

    public string SurnameI { get; set; } = null!;

    public string NameI { get; set; } = null!;

    public string Otchestvo { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public DateOnly DateB { get; set; }

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string House { get; set; } = null!;

    public int Flat { get; set; }

    public string PassNom { get; set; } = null!;

    public string PassSerial { get; set; } = null!;

    public virtual ICollection<Rec> Recs { get; set; } = new List<Rec>();

    public virtual ICollection<Stud> Studs { get; set; } = new List<Stud>();
}
