using System;
using System.Collections.Generic;

namespace BullseyeDesktopApp.Models;

public partial class Inventory
{
    public int ItemId { get; set; }

    public int SiteId { get; set; }

    public int Quantity { get; set; }

    public string ItemLocation { get; set; } = null!;

    public int? ReorderThreshold { get; set; }

    public int MaxReorderWarning { get; set; }

    public virtual Item Item { get; set; } = null!;

    public virtual Site Site { get; set; } = null!;
}
