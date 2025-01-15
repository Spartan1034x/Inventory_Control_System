using System;
using System.Collections.Generic;

namespace BullseyeDesktopApp.Models;

public partial class Txn
{
    public int TxnId { get; set; }

    public int EmployeeId { get; set; }

    public int SiteIdto { get; set; }

    public int SiteIdfrom { get; set; }

    public string TxnStatus { get; set; } = null!;

    public DateTime ShipDate { get; set; }

    public string TxnType { get; set; } = null!;

    public string BarCode { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public int? DeliveryId { get; set; }

    public sbyte? EmergencyDelivery { get; set; }

    public string? Notes { get; set; }

    public virtual Delivery? Delivery { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Site SiteIdfromNavigation { get; set; } = null!;

    public virtual Site SiteIdtoNavigation { get; set; } = null!;

    public virtual Txnstatus TxnStatusNavigation { get; set; } = null!;

    public virtual Txntype TxnTypeNavigation { get; set; } = null!;

    public virtual ICollection<Txnitem> Txnitems { get; set; } = new List<Txnitem>();
}
