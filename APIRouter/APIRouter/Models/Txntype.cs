using System;
using System.Collections.Generic;

namespace APIRouter.Models;

public partial class Txntype
{
    public string TxnType1 { get; set; } = null!;

    public sbyte Active { get; set; }

    public virtual ICollection<Txnaudit> Txnaudits { get; set; } = new List<Txnaudit>();

    public virtual ICollection<Txn> Txns { get; set; } = new List<Txn>();
}
