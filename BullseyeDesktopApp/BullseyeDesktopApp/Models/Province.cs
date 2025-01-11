using System;
using System.Collections.Generic;

namespace BullseyeDesktopApp.Models;

public partial class Province
{
    public string ProvinceId { get; set; } = null!;

    public string ProvinceName { get; set; } = null!;

    public string CountryCode { get; set; } = null!;

    public virtual ICollection<Site> Sites { get; set; } = new List<Site>();

    public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();
}
