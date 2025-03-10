using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace APIRouter.Models;

public partial class Vehicle
{
    public string VehicleType { get; set; } = null!;

    public decimal MaxWeight { get; set; }

    public decimal HourlyTruckCost { get; set; }

    public decimal CostPerKm { get; set; }

    public string Notes { get; set; } = null!;

    public sbyte Active { get; set; }

    [JsonIgnore] // Needed to prevent constant looping error in Create actions
    public virtual ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();
}
