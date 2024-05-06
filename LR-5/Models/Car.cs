using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LR_5.Models;

public partial class Car
{
    public int CarId { get; set; }

    public string Brand { get; set; } = null!;

    public string Model { get; set; } = null!;

    public string TypeC { get; set; } = null!;

    public string TypeKpp { get; set; } = null!;

    public byte[]? Img { get; set; }

    [NotMapped]
    public IFormFile? ImageFile { get; set; }

    public virtual ICollection<Rec> Recs { get; set; } = new List<Rec>();
}
