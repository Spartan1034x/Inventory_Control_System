using System;
using System.Collections.Generic;

namespace BullseyeDesktopApp.Models;

public partial class Txnitem
{
    public int TxnId { get; set; }

    public int ItemId { get; set; }

    public int Quantity { get; set; }

    public int ItemLocation { get; set; }

    public string? Notes { get; set; }

    public virtual Item Item { get; set; } = null!;

    public virtual Txn Txn { get; set; } = null!;
}
