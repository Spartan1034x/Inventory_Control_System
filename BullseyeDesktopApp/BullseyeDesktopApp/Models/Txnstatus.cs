using System;
using System.Collections.Generic;

namespace BullseyeDesktopApp.Models;

public partial class Txnstatus
{
    public string StatusName { get; set; } = null!;

    public string StatusDescription { get; set; } = null!;

    public virtual ICollection<Txn> Txns { get; set; } = new List<Txn>();
}
