using System;
using System.Collections.Generic;

namespace CaseZV.Models;

public partial class Gun
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Img { get; set; }

    public double Price { get; set; }

    public virtual ICollection<GunsOfCase> GunsOfCases { get; set; } = new List<GunsOfCase>();
}
