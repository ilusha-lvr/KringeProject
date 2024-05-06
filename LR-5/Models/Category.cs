using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LR_5.Models;

public partial class Category
{
    public int CatId { get; set; }

    public int TimeT { get; set; }

    public int TimeP { get; set; }

    public string TypeKpp { get; set; } = null!;

    public decimal Price { get; set; }

    public int TimeLes { get; set; }

    [Column("name")]
    public string? NameC { get; set; }

    public virtual ICollection<Stud> Studs { get; set; } = new List<Stud>();
}
