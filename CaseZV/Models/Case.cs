using System;
using System.Collections.Generic;

namespace CaseZV.Models;

public partial class Case
{
    public int Id { get; set; }

    public string? Img { get; set; }

    public int Price { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<GunsOfCase> GunsOfCases { get; set; } = new List<GunsOfCase>();
}
