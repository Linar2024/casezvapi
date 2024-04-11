using System;
using System.Collections.Generic;

namespace CaseZV.Models;

public partial class Balance
{
    public int Id { get; set; }

    public double Sum { get; set; }

    public int UserId { get; set; }

    public virtual User? User { get; set; } = null!;
}
