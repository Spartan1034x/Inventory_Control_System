using System;
using System.Collections.Generic;

namespace BullseyeDesktopApp.Models;

public partial class Txnaudit
{
    public int TxnAuditId { get; set; }

    public int TxnId { get; set; }

    public string TxnType { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime TxnDate { get; set; }

    public int SiteId { get; set; }

    public int? DeliveryId { get; set; }

    public virtual Delivery? Delivery { get; set; }

    public virtual Site Site { get; set; } = null!;

    public virtual Txntype TxnTypeNavigation { get; set; } = null!;
}
