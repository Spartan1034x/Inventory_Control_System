using System;
using System.Collections.Generic;

namespace APIRouter.Models;

public partial class Txn
{
    public int TxnId { get; set; }

    public int SiteIdto { get; set; }

    public int SiteIdfrom { get; set; }

    public string Status { get; set; } = null!;

    public DateTime ShipDate { get; set; }

    public string TxnType { get; set; } = null!;

    public string BarCode { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public int? DeliveryId { get; set; }

    public bool? EmergencyDelivery { get; set; }

    public virtual Delivery? Delivery { get; set; }

    public virtual Site SiteIdfromNavigation { get; set; } = null!;

    public virtual Site SiteIdtoNavigation { get; set; } = null!;

    public virtual Txnstatus StatusNavigation { get; set; } = null!;

    public virtual Txntype TxnTypeNavigation { get; set; } = null!;

    public virtual ICollection<Txnitem> Txnitems { get; set; } = new List<Txnitem>();
}
