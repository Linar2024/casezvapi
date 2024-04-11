using System;
using System.Collections.Generic;

namespace CaseZV.Models;

public partial class User
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Balance> Balances { get; set; } = new List<Balance>();
}
