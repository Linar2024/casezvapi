using System;
using System.Collections.Generic;

namespace CaseZV.Models;

public partial class GunsOfCase
{
    public int Id { get; set; }

    public int Cases { get; set; }

    public int Gun { get; set; }

    public double Chance { get; set; }

    public virtual Case CasesNavigation { get; set; } = null!;

    public virtual Gun GunNavigation { get; set; } = null!;
}
